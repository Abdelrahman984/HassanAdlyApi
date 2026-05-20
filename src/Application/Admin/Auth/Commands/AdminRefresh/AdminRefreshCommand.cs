using HassanAdly.Application.Admin.Auth.Dtos;
using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Auth.Commands.AdminRefresh;

public sealed record AdminRefreshCommand(string RefreshToken) : IRequest<AdminAuthTokensDto?>;

public sealed class AdminRefreshCommandHandler : IRequestHandler<AdminRefreshCommand, AdminAuthTokensDto?>
{
    private static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromDays(30);

    private readonly IAdminRefreshTokenRepository _adminRefreshTokenRepository;
    private readonly IAdminUserRepository _adminUserRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly ITokenHasher _tokenHasher;
    private readonly TimeProvider _timeProvider;

    public AdminRefreshCommandHandler(
        IAdminRefreshTokenRepository adminRefreshTokenRepository,
        IAdminUserRepository adminUserRepository,
        IJwtTokenService jwtTokenService,
        IRefreshTokenGenerator refreshTokenGenerator,
        ITokenHasher tokenHasher,
        TimeProvider timeProvider)
    {
        _adminRefreshTokenRepository = adminRefreshTokenRepository;
        _adminUserRepository = adminUserRepository;
        _jwtTokenService = jwtTokenService;
        _refreshTokenGenerator = refreshTokenGenerator;
        _tokenHasher = tokenHasher;
        _timeProvider = timeProvider;
    }

    public async Task<AdminAuthTokensDto?> Handle(AdminRefreshCommand request, CancellationToken cancellationToken)
    {
        var tokenHash = _tokenHasher.Hash(request.RefreshToken);
        var existingToken = await _adminRefreshTokenRepository.GetByTokenHashAsync(tokenHash, cancellationToken);
        if (existingToken is null || existingToken.RevokedAtUtc is not null)
        {
            return null;
        }

        var now = _timeProvider.GetUtcNow();
        if (existingToken.ExpiresAtUtc <= now)
        {
            return null;
        }

        var adminUser = await _adminUserRepository.GetByIdAsync(existingToken.AdminUserId, cancellationToken);
        if (adminUser is null || !adminUser.IsActive)
        {
            return null;
        }

        existingToken.RevokedAtUtc = now;
        existingToken.UpdatedAtUtc = now;

        var accessToken = _jwtTokenService.CreateAdminAccessToken(adminUser);

        var refreshTokenPlain = _refreshTokenGenerator.Generate();
        var refreshToken = new Domain.Entities.AdminRefreshToken
        {
            Id = 0,
            AdminUserId = adminUser.Id,
            TokenHash = _tokenHasher.Hash(refreshTokenPlain),
            ExpiresAtUtc = now.Add(RefreshTokenLifetime),
            CreatedAtUtc = now,
            UpdatedAtUtc = now
        };

        await _adminRefreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        await _adminRefreshTokenRepository.SaveChangesAsync(cancellationToken);

        return new AdminAuthTokensDto(accessToken.AccessToken, accessToken.ExpiresAtUtc, refreshTokenPlain);
    }
}
