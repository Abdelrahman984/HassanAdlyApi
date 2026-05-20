using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class SheikhRepository : ISheikhRepository
{
    private readonly AppDbContext _dbContext;

    public SheikhRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Sheikh?> GetActiveAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Sheikhs.AsNoTracking().FirstOrDefaultAsync(x => x.IsActive, cancellationToken);
    }
}
