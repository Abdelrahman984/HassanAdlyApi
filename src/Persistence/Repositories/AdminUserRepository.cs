using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class AdminUserRepository : IAdminUserRepository
{
    private readonly AppDbContext _dbContext;

    public AdminUserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<AdminUser?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return _dbContext.AdminUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public Task<AdminUser?> GetByIdAsync(long adminUserId, CancellationToken cancellationToken)
    {
        return _dbContext.AdminUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == adminUserId, cancellationToken);
    }
}
