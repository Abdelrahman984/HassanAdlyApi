using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Domain.Enums;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.Repositories;

public sealed class AudioTrackRepository : IAudioTrackRepository
{
    private readonly AppDbContext _dbContext;

    public AudioTrackRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<AudioTrack?> ResolveAsync(short surahId, short qiraaId, CancellationToken cancellationToken)
    {
        return _dbContext.AudioTracks
            .AsNoTracking()
            .Include(x => x.Surah)
            .Include(x => x.Qiraa)
            .Where(x => x.SurahId == surahId && x.QiraaId == qiraaId)
            .OrderByDescending(x => x.Version)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task<AudioTrack?> GetByIdAsync(long audioTrackId, CancellationToken cancellationToken)
    {
        return _dbContext.AudioTracks
            .AsNoTracking()
            .Include(x => x.Surah)
            .Include(x => x.Qiraa)
            .FirstOrDefaultAsync(x => x.Id == audioTrackId, cancellationToken);
    }

    public async Task<IReadOnlyList<AudioTrack>> GetListAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        return await _dbContext.AudioTracks
            .AsNoTracking()
            .OrderByDescending(x => x.UpdatedAtUtc)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        return _dbContext.AudioTracks.CountAsync(cancellationToken);
    }

    public async Task<bool> UpdateStatusAsync(long audioTrackId, AudioTrackStatus status, CancellationToken cancellationToken)
    {
        var track = await _dbContext.AudioTracks.FirstOrDefaultAsync(x => x.Id == audioTrackId, cancellationToken);
        if (track is null)
        {
            return false;
        }

        track.Status = status;
        track.UpdatedAtUtc = TimeProvider.System.GetUtcNow();
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
