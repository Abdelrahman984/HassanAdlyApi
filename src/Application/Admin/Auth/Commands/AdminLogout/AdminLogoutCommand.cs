using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Auth.Commands.AdminLogout;

public sealed record AdminLogoutCommand(string RefreshToken) : IRequest<bool>;

public sealed class AdminLogoutCommandHandler : IRequestHandler<AdminLogoutCommand, bool>
{
    private readonly IAdminRefreshTokenRepository _adminRefreshTokenRepository;
    private readonly ITokenHasher _tokenHasher;
    private readonly TimeProvider _timeProvider;

    public AdminLogoutCommandHandler(
        IAdminRefreshTokenRepository adminRefreshTokenRepository,
        ITokenHasher tokenHasher,
        TimeProvider timeProvider)
    {
        _adminRefreshTokenRepository = adminRefreshTokenRepository;
        _tokenHasher = tokenHasher;
        _timeProvider = timeProvider;
    }

    public async Task<bool> Handle(AdminLogoutCommand request, CancellationToken cancellationToken)
    {
        var tokenHash = _tokenHasher.Hash(request.RefreshToken);
        var existingToken = await _adminRefreshTokenRepository.GetByTokenHashAsync(tokenHash, cancellationToken);
        if (existingToken is null || existingToken.RevokedAtUtc is not null)
        {
            return false;
        }

        existingToken.RevokedAtUtc = _timeProvider.GetUtcNow();
        existingToken.UpdatedAtUtc = _timeProvider.GetUtcNow();
        await _adminRefreshTokenRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
