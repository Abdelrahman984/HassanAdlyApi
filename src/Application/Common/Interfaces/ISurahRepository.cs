using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface ISurahRepository
{
    Task<IReadOnlyList<Surah>> GetListAsync(string? search, bool publishedOnly, int page, int pageSize, CancellationToken cancellationToken);
    Task<int> GetCountAsync(string? search, bool publishedOnly, CancellationToken cancellationToken);
    Task<Surah?> GetByIdAsync(short surahId, CancellationToken cancellationToken);
}
