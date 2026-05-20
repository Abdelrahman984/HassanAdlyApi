using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class SurahRepository : ISurahRepository
{
    private readonly AppDbContext _dbContext;

    public SurahRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<Surah>> GetListAsync(string? search, bool publishedOnly, int page, int pageSize, CancellationToken cancellationToken)
    {
        var query = BaseQuery(publishedOnly);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(x =>
                x.NameArabic.Contains(s) ||
                x.NameTransliteration.Contains(s) ||
                x.SearchNormalizedArabic.Contains(s));
        }

        return await query
            .OrderBy(x => x.DisplayOrder)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public Task<int> GetCountAsync(string? search, bool publishedOnly, CancellationToken cancellationToken)
    {
        var query = BaseQuery(publishedOnly);

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(x =>
                x.NameArabic.Contains(s) ||
                x.NameTransliteration.Contains(s) ||
                x.SearchNormalizedArabic.Contains(s));
        }

        return query.CountAsync(cancellationToken);
    }

    public Task<Surah?> GetByIdAsync(short surahId, CancellationToken cancellationToken)
    {
        return _dbContext.Surahs
            .AsNoTracking()
            .Include(x => x.AudioTracks)
            .ThenInclude(t => t.Qiraa)
            .FirstOrDefaultAsync(x => x.Id == surahId, cancellationToken);
    }

    private IQueryable<Surah> BaseQuery(bool publishedOnly)
    {
        IQueryable<Surah> query = _dbContext.Surahs.AsNoTracking().Include(x => x.AudioTracks);
        if (publishedOnly)
        {
            query = query.Where(x => x.IsPublished);
        }
        return query;
    }
}
