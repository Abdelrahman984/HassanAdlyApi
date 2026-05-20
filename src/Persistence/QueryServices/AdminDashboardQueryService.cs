using HassanAdly.Application.Admin.Dashboard.Queries.GetAdminDashboard;
using HassanAdly.Domain.Enums;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.QueryServices;

public sealed class AdminDashboardQueryService : IAdminDashboardQueryService
{
    private readonly AppDbContext _dbContext;

    public AdminDashboardQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AdminDashboardDto> GetAsync(CancellationToken cancellationToken)
    {
        var activeSurahsCount = await _dbContext.Surahs.CountAsync(x => x.IsPublished, cancellationToken);
        var activeQiraatCount = await _dbContext.Qiraat.CountAsync(x => x.IsPublished, cancellationToken);
        var latestTracks = await _dbContext.AudioTracks
            .AsNoTracking()
            .Include(x => x.Surah)
            .Include(x => x.Qiraa)
            .GroupBy(x => new { x.SurahId, x.QiraaId })
            .Select(g => g.OrderByDescending(x => x.Version).First())
            .ToListAsync(cancellationToken);

        var totalPublishedTracks = latestTracks.Count(x => x.Status == AudioTrackStatus.Published);
        var totalCompletedTracks = latestTracks.Count(x => x.Status is AudioTrackStatus.Ready or AudioTrackStatus.Published);
        var missingRecordingsCount = Math.Max(0, (activeSurahsCount * activeQiraatCount) - latestTracks.Count);
        var storageUsageBytes = latestTracks.Sum(x => x.FileSizeBytes);
        var failedTracks = latestTracks
            .Where(x => x.Status == AudioTrackStatus.Failed)
            .OrderByDescending(x => x.UpdatedAtUtc)
            .ToList();

        var recentUploads = latestTracks
            .OrderByDescending(x => x.UpdatedAtUtc)
            .Take(5)
            .Select(x => new AdminDashboardRecentTrackDto(
                x.Id,
                x.TitleArabic,
                x.Surah?.NameArabic ?? string.Empty,
                x.Qiraa?.NameArabic ?? string.Empty,
                x.Status.ToString(),
                x.UpdatedAtUtc))
            .ToList();

        return new AdminDashboardDto(
            totalPublishedTracks,
            totalCompletedTracks,
            missingRecordingsCount,
            storageUsageBytes,
            failedTracks.Count,
            recentUploads,
            failedTracks
                .Take(5)
                .Select(x => new AdminDashboardFailedTrackDto(
                    x.Id,
                    x.TitleArabic,
                    x.Surah?.NameArabic ?? string.Empty,
                    x.Qiraa?.NameArabic ?? string.Empty,
                    x.UpdatedAtUtc))
                .ToList());
    }
}
