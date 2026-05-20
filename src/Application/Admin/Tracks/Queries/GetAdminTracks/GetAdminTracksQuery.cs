using HassanAdly.Application.Admin.Tracks.Dtos;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Application.Common.Models;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Queries.GetAdminTracks;

public sealed record GetAdminTracksQuery(int Page = 1, int PageSize = 20) : IRequest<PagedResult<AdminTrackListItemDto>>;

public sealed class GetAdminTracksQueryHandler : IRequestHandler<GetAdminTracksQuery, PagedResult<AdminTrackListItemDto>>
{
    private readonly IAudioTrackRepository _audioTrackRepository;

    public GetAdminTracksQueryHandler(IAudioTrackRepository audioTrackRepository)
    {
        _audioTrackRepository = audioTrackRepository;
    }

    public async Task<PagedResult<AdminTrackListItemDto>> Handle(GetAdminTracksQuery request, CancellationToken cancellationToken)
    {
        var page = request.Page <= 0 ? 1 : request.Page;
        var pageSize = request.PageSize <= 0 ? 20 : request.PageSize;

        var tracks = await _audioTrackRepository.GetListAsync(page, pageSize, cancellationToken);
        var totalCount = await _audioTrackRepository.GetCountAsync(cancellationToken);

        var items = tracks.Select(t => new AdminTrackListItemDto(
            t.Id,
            t.SheikhId,
            t.SurahId,
            t.QiraaId,
            t.TitleArabic,
            t.Status,
            t.DurationSeconds,
            t.Version)).ToList();

        return new PagedResult<AdminTrackListItemDto>(items, page, pageSize, totalCount);
    }
}
