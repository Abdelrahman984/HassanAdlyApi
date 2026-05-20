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
            .Include(x => x.Surah)
            .Include(x => x.Qiraa)
            .Include(x => x.Sheikh)
            .FirstOrDefaultAsync(x => x.Id == audioTrackId, cancellationToken);
    }

    public Task<AudioTrack?> GetBySheikhSurahAndQiraaAsync(long sheikhId, short surahId, short qiraaId, CancellationToken cancellationToken)
    {
        return _dbContext.AudioTracks
            .FirstOrDefaultAsync(x => x.SheikhId == sheikhId && x.SurahId == surahId && x.QiraaId == qiraaId, cancellationToken);
    }

    public async Task<IReadOnlyList<AudioTrack>> GetListAsync(int page, int pageSize, string? search, AudioTrackStatus? status, short? surahId, short? qiraaId, CancellationToken cancellationToken)
    {
        return await BaseAdminQuery(search, status, surahId, qiraaId)
            .OrderByDescending(x => x.UpdatedAtUtc)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public Task<int> GetCountAsync(string? search, AudioTrackStatus? status, short? surahId, short? qiraaId, CancellationToken cancellationToken)
    {
        return BaseAdminQuery(search, status, surahId, qiraaId).CountAsync(cancellationToken);
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

    public async Task AddAsync(AudioTrack audioTrack, CancellationToken cancellationToken)
    {
        await _dbContext.AudioTracks.AddAsync(audioTrack, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    private IQueryable<AudioTrack> BaseAdminQuery(string? search, AudioTrackStatus? status, short? surahId, short? qiraaId)
    {
        var query = _dbContext.AudioTracks
            .AsNoTracking()
            .Include(x => x.Surah)
            .Include(x => x.Qiraa)
            .Include(x => x.Sheikh)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var trimmed = search.Trim();
            query = query.Where(x =>
                x.TitleArabic.Contains(trimmed) ||
                x.Surah!.NameArabic.Contains(trimmed) ||
                x.Qiraa!.NameArabic.Contains(trimmed));
        }

        if (status.HasValue)
        {
            query = query.Where(x => x.Status == status.Value);
        }

        if (surahId.HasValue)
        {
            query = query.Where(x => x.SurahId == surahId.Value);
        }

        if (qiraaId.HasValue)
        {
            query = query.Where(x => x.QiraaId == qiraaId.Value);
        }

        return query;
    }
}
