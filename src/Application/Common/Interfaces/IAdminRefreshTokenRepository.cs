using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface IAdminRefreshTokenRepository
{
    Task<AdminRefreshToken?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken);
    Task AddAsync(AdminRefreshToken refreshToken, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
