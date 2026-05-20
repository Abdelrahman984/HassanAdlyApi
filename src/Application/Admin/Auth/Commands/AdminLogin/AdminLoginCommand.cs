using HassanAdly.Application.Admin.Auth.Dtos;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using MediatR;

namespace HassanAdly.Application.Admin.Auth.Commands.AdminLogin;

public sealed record AdminLoginCommand(string Email, string Password) : IRequest<AdminAuthTokensDto?>;

public sealed class AdminLoginCommandHandler : IRequestHandler<AdminLoginCommand, AdminAuthTokensDto?>
{
    private static readonly TimeSpan RefreshTokenLifetime = TimeSpan.FromDays(30);

    private readonly IAdminUserRepository _adminUserRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IRefreshTokenGenerator _refreshTokenGenerator;
    private readonly ITokenHasher _tokenHasher;
    private readonly IAdminRefreshTokenRepository _adminRefreshTokenRepository;
    private readonly TimeProvider _timeProvider;

    public AdminLoginCommandHandler(
        IAdminUserRepository adminUserRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService,
        IRefreshTokenGenerator refreshTokenGenerator,
        ITokenHasher tokenHasher,
        IAdminRefreshTokenRepository adminRefreshTokenRepository,
        TimeProvider timeProvider)
    {
        _adminUserRepository = adminUserRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
        _refreshTokenGenerator = refreshTokenGenerator;
        _tokenHasher = tokenHasher;
        _adminRefreshTokenRepository = adminRefreshTokenRepository;
        _timeProvider = timeProvider;
    }

    public async Task<AdminAuthTokensDto?> Handle(AdminLoginCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim();
        var adminUser = await _adminUserRepository.GetByEmailAsync(email, cancellationToken);
        if (adminUser is null || !adminUser.IsActive)
        {
            return null;
        }

        if (!_passwordHasher.Verify(adminUser, request.Password))
        {
            return null;
        }

        var accessToken = _jwtTokenService.CreateAdminAccessToken(adminUser);

        var refreshTokenPlain = _refreshTokenGenerator.Generate();
        var refreshTokenHash = _tokenHasher.Hash(refreshTokenPlain);

        var refreshToken = new AdminRefreshToken
        {
            Id = 0,
            AdminUserId = adminUser.Id,
            TokenHash = refreshTokenHash,
            ExpiresAtUtc = _timeProvider.GetUtcNow().Add(RefreshTokenLifetime),
            CreatedAtUtc = _timeProvider.GetUtcNow(),
            UpdatedAtUtc = _timeProvider.GetUtcNow()
        };

        await _adminRefreshTokenRepository.AddAsync(refreshToken, cancellationToken);
        await _adminRefreshTokenRepository.SaveChangesAsync(cancellationToken);

        return new AdminAuthTokensDto(accessToken.AccessToken, accessToken.ExpiresAtUtc, refreshTokenPlain);
    }
}
