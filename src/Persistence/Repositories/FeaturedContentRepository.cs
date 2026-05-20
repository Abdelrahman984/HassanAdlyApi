using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class FeaturedContentRepository : IFeaturedContentRepository
{
    private readonly AppDbContext _dbContext;

    public FeaturedContentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<FeaturedContent>> GetListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.FeaturedContents
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }

    public Task<FeaturedContent?> GetByIdAsync(long featuredContentId, CancellationToken cancellationToken)
    {
        return _dbContext.FeaturedContents.FirstOrDefaultAsync(x => x.Id == featuredContentId, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
