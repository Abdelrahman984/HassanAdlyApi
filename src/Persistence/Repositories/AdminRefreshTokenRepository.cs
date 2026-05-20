using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class AdminRefreshTokenRepository : IAdminRefreshTokenRepository
{
    private readonly AppDbContext _dbContext;

    public AdminRefreshTokenRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<AdminRefreshToken?> GetByTokenHashAsync(string tokenHash, CancellationToken cancellationToken)
    {
        return _dbContext.AdminRefreshTokens.FirstOrDefaultAsync(x => x.TokenHash == tokenHash, cancellationToken);
    }

    public Task AddAsync(AdminRefreshToken refreshToken, CancellationToken cancellationToken)
    {
        return _dbContext.AdminRefreshTokens.AddAsync(refreshToken, cancellationToken).AsTask();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
