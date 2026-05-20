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

    public Task<Sheikh?> GetAdminAggregateAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Sheikhs
            .Include(x => x.EducationEntries.OrderBy(item => item.DisplayOrder))
            .Include(x => x.ExperienceEntries.OrderBy(item => item.DisplayOrder))
            .Include(x => x.Teachers.OrderBy(item => item.DisplayOrder))
            .Include(x => x.HighlightCards.OrderBy(item => item.DisplayOrder))
            .FirstOrDefaultAsync(x => x.IsActive, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
