using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class QiraaRepository : IQiraaRepository
{
    private readonly AppDbContext _dbContext;

    public QiraaRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Qiraa>> GetListAsync(bool publishedOnly, CancellationToken cancellationToken)
    {
        var query = _dbContext.Qiraat.AsNoTracking();
        if (publishedOnly)
        {
            query = query.Where(x => x.IsPublished);
        }

        return await query
            .OrderBy(x => x.DisplayOrder)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Qiraa>> SearchAsync(string query, int maxResults, bool publishedOnly, CancellationToken cancellationToken)
    {
        var q = query.Trim();
        var dbQuery = _dbContext.Qiraat.AsNoTracking();
        if (publishedOnly)
        {
            dbQuery = dbQuery.Where(x => x.IsPublished);
        }

        return await dbQuery
            .Where(x =>
                x.NameArabic.Contains(q) ||
                x.RawiArabic.Contains(q) ||
                (x.ImamArabic != null && x.ImamArabic.Contains(q)) ||
                x.Slug.Contains(q))
            .OrderBy(x => x.DisplayOrder)
            .Take(maxResults)
            .ToListAsync(cancellationToken);
    }

    public Task<Qiraa?> GetByIdAsync(short qiraaId, CancellationToken cancellationToken)
    {
        return _dbContext.Qiraat.AsNoTracking().FirstOrDefaultAsync(x => x.Id == qiraaId, cancellationToken);
    }
}
