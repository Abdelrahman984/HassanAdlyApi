using HassanAdly.Domain.Entities;
using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Common.Interfaces;

public interface IAudioTrackRepository
{
    Task<AudioTrack?> ResolveAsync(short surahId, short qiraaId, CancellationToken cancellationToken);
    Task<AudioTrack?> GetByIdAsync(long audioTrackId, CancellationToken cancellationToken);
    Task<AudioTrack?> GetBySheikhSurahAndQiraaAsync(long sheikhId, short surahId, short qiraaId, CancellationToken cancellationToken);
    Task<IReadOnlyList<AudioTrack>> GetListAsync(int page, int pageSize, string? search, AudioTrackStatus? status, short? surahId, short? qiraaId, CancellationToken cancellationToken);
    Task<int> GetCountAsync(string? search, AudioTrackStatus? status, short? surahId, short? qiraaId, CancellationToken cancellationToken);
    Task<bool> UpdateStatusAsync(long audioTrackId, AudioTrackStatus status, CancellationToken cancellationToken);
    Task AddAsync(AudioTrack audioTrack, CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
