using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Application.Common.Models;
using MediatR;

namespace HassanAdly.Application.Catalog.Queries.GetSurahs;

public sealed record GetSurahsQuery(
    string? Search,
    int Page = 1,
    int PageSize = 20,
    bool PublishedOnly = true) : IRequest<PagedResult<SurahListItemDto>>;

public sealed class GetSurahsQueryHandler : IRequestHandler<GetSurahsQuery, PagedResult<SurahListItemDto>>
{
    private readonly ISurahRepository _surahRepository;

    public GetSurahsQueryHandler(ISurahRepository surahRepository)
    {
        _surahRepository = surahRepository;
    }

    public async Task<PagedResult<SurahListItemDto>> Handle(GetSurahsQuery request, CancellationToken cancellationToken)
    {
        var page = request.Page <= 0 ? 1 : request.Page;
        var pageSize = request.PageSize <= 0 ? 20 : request.PageSize;

        var surahs = await _surahRepository.GetListAsync(request.Search, request.PublishedOnly, page, pageSize, cancellationToken);
        var totalCount = await _surahRepository.GetCountAsync(request.Search, request.PublishedOnly, cancellationToken);

        var items = surahs
            .Select(s => new SurahListItemDto(
                s.Id,
                s.NameArabic,
                s.NameTransliteration,
                s.RevelationType,
                s.VerseCount,
                s.AudioTracks.Count(t => t.Status == Domain.Enums.AudioTrackStatus.Published)))
            .ToList();

        return new PagedResult<SurahListItemDto>(items, page, pageSize, totalCount);
    }
}
