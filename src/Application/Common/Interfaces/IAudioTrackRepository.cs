using HassanAdly.Domain.Entities;
using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Common.Interfaces;

public interface IAudioTrackRepository
{
    Task<AudioTrack?> ResolveAsync(short surahId, short qiraaId, CancellationToken cancellationToken);
    Task<AudioTrack?> GetByIdAsync(long audioTrackId, CancellationToken cancellationToken);
    Task<IReadOnlyList<AudioTrack>> GetListAsync(int page, int pageSize, CancellationToken cancellationToken);
    Task<int> GetCountAsync(CancellationToken cancellationToken);
    Task<bool> UpdateStatusAsync(long audioTrackId, AudioTrackStatus status, CancellationToken cancellationToken);
}
