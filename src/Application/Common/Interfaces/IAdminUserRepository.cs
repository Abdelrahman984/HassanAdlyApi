using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface IAdminUserRepository
{
    Task<AdminUser?> GetByEmailAsync(string email, CancellationToken cancellationToken);
    Task<AdminUser?> GetByIdAsync(long adminUserId, CancellationToken cancellationToken);
}
