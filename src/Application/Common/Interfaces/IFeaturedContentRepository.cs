using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface IFeaturedContentRepository
{
    Task<IReadOnlyList<FeaturedContent>> GetListAsync(CancellationToken cancellationToken);
    Task<FeaturedContent?> GetByIdAsync(long featuredContentId, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
