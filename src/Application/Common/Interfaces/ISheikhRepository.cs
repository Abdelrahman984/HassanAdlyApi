using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface ISheikhRepository
{
    Task<Sheikh?> GetActiveAsync(CancellationToken cancellationToken);
}
