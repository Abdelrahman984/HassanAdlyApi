using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Search.Queries.Search;

public sealed record SearchQuery(string Q) : IRequest<SearchResultDto>;

public sealed class SearchQueryHandler : IRequestHandler<SearchQuery, SearchResultDto>
{
    private const int DefaultMaxResults = 20;

    private readonly ISurahRepository _surahRepository;
    private readonly IQiraaRepository _qiraaRepository;
    private readonly ISheikhRepository _sheikhRepository;

    public SearchQueryHandler(
        ISurahRepository surahRepository,
        IQiraaRepository qiraaRepository,
        ISheikhRepository sheikhRepository)
    {
        _surahRepository = surahRepository;
        _qiraaRepository = qiraaRepository;
        _sheikhRepository = sheikhRepository;
    }

    public async Task<SearchResultDto> Handle(SearchQuery request, CancellationToken cancellationToken)
    {
        var query = request.Q?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(query))
        {
            return new SearchResultDto(string.Empty, Array.Empty<SearchSurahDto>(), Array.Empty<SearchQiraaDto>(), Array.Empty<SearchSheikhDto>());
        }

        var surahs = await _surahRepository.GetListAsync(query, publishedOnly: true, page: 1, pageSize: DefaultMaxResults, cancellationToken);
        var qiraat = await _qiraaRepository.SearchAsync(query, DefaultMaxResults, publishedOnly: true, cancellationToken);

        var activeSheikh = await _sheikhRepository.GetActiveAsync(cancellationToken);
        var sheikhMatches = activeSheikh is null
            ? Array.Empty<SearchSheikhDto>()
            : (activeSheikh.DisplayNameArabic.Contains(query, StringComparison.OrdinalIgnoreCase)
                    ? new[] { new SearchSheikhDto(activeSheikh.Id, activeSheikh.DisplayNameArabic) }
                    : Array.Empty<SearchSheikhDto>());

        return new SearchResultDto(
            query,
            surahs.Select(s => new SearchSurahDto(s.Id, s.NameArabic, s.NameTransliteration)).ToList(),
            qiraat.Select(q => new SearchQiraaDto(q.Id, q.NameArabic, q.RawiArabic)).ToList(),
            sheikhMatches);
    }
}
