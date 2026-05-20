using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Surahs.Queries.GetAdminSurahs;

public sealed record GetAdminSurahsQuery() : IRequest<IReadOnlyList<AdminSurahDto>>;

public sealed record AdminSurahDto(
    short Id,
    string NameArabic,
    string NameTransliteration,
    string? NameEnglish,
    string? SeoTitleArabic,
    string? SeoDescriptionArabic,
    string? SeoTitleEnglish,
    string? SeoDescriptionEnglish,
    string RevelationType,
    short VerseCount,
    short DisplayOrder,
    bool IsPublished);

public sealed class GetAdminSurahsQueryHandler : IRequestHandler<GetAdminSurahsQuery, IReadOnlyList<AdminSurahDto>>
{
    private readonly ISurahRepository _surahRepository;

    public GetAdminSurahsQueryHandler(ISurahRepository surahRepository)
    {
        _surahRepository = surahRepository;
    }

    public async Task<IReadOnlyList<AdminSurahDto>> Handle(GetAdminSurahsQuery request, CancellationToken cancellationToken)
    {
        var surahs = await _surahRepository.GetAllAsync(cancellationToken);
        return surahs
            .Select(x => new AdminSurahDto(
                x.Id,
                x.NameArabic,
                x.NameTransliteration,
                x.NameEnglish,
                x.SeoTitleArabic,
                x.SeoDescriptionArabic,
                x.SeoTitleEnglish,
                x.SeoDescriptionEnglish,
                x.RevelationType.ToString(),
                x.VerseCount,
                x.DisplayOrder,
                x.IsPublished))
            .ToList();
    }
}
