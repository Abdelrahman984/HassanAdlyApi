using MediatR;

namespace HassanAdly.Application.Admin.Dashboard.Queries.GetAdminDashboard;

public sealed record GetAdminDashboardQuery() : IRequest<AdminDashboardDto>;

public sealed record AdminDashboardDto(
    int TotalPublishedTracks,
    int TotalCompletedTracks,
    int MissingRecordingsCount,
    long StorageUsageBytes,
    int FailedProcessingCount,
    IReadOnlyList<AdminDashboardRecentTrackDto> RecentUploads,
    IReadOnlyList<AdminDashboardFailedTrackDto> FailedProcessingItems);

public sealed record AdminDashboardRecentTrackDto(
    long Id,
    string TitleArabic,
    string SurahNameArabic,
    string QiraaNameArabic,
    string Status,
    DateTimeOffset UpdatedAtUtc);

public sealed record AdminDashboardFailedTrackDto(
    long Id,
    string TitleArabic,
    string SurahNameArabic,
    string QiraaNameArabic,
    DateTimeOffset UpdatedAtUtc);

public interface IAdminDashboardQueryService
{
    Task<AdminDashboardDto> GetAsync(CancellationToken cancellationToken);
}

public sealed class GetAdminDashboardQueryHandler : IRequestHandler<GetAdminDashboardQuery, AdminDashboardDto>
{
    private readonly IAdminDashboardQueryService _queryService;

    public GetAdminDashboardQueryHandler(IAdminDashboardQueryService queryService)
    {
        _queryService = queryService;
    }

    public Task<AdminDashboardDto> Handle(GetAdminDashboardQuery request, CancellationToken cancellationToken)
    {
        return _queryService.GetAsync(cancellationToken);
    }
}
