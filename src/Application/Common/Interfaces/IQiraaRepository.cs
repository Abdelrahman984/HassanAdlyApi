using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface IQiraaRepository
{
    Task<IReadOnlyList<Qiraa>> GetListAsync(bool publishedOnly, CancellationToken cancellationToken);
    Task<IReadOnlyList<Qiraa>> SearchAsync(string query, int maxResults, bool publishedOnly, CancellationToken cancellationToken);
    Task<Qiraa?> GetByIdAsync(short qiraaId, CancellationToken cancellationToken);
}
