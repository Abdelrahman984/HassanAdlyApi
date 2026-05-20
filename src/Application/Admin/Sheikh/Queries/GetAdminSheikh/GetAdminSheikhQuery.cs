using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Sheikh.Queries.GetAdminSheikh;

public sealed record GetAdminSheikhQuery() : IRequest<AdminSheikhDto?>;

public sealed record AdminSheikhDto(
    long Id,
    string Slug,
    string DisplayNameArabic,
    string? DisplayNameEnglish,
    string FullNameArabic,
    DateOnly? BirthDate,
    string? BirthPlaceArabic,
    string BiographyArabic,
    string ShortDescriptionArabic,
    string ProfileImageUrl,
    string? HeroImageUrl,
    string? HeroTitleArabic,
    string? HeroSubtitleArabic,
    bool IsActive,
    IReadOnlyList<AdminSheikhEducationDto> EducationEntries,
    IReadOnlyList<AdminSheikhExperienceDto> ExperienceEntries,
    IReadOnlyList<AdminSheikhTeacherDto> Teachers,
    IReadOnlyList<AdminSheikhHighlightCardDto> HighlightCards);

public sealed record AdminSheikhEducationDto(long Id, string TitleArabic, string? InstitutionArabic, string? DescriptionArabic, short DisplayOrder);
public sealed record AdminSheikhExperienceDto(long Id, string TitleArabic, string? DescriptionArabic, short DisplayOrder);
public sealed record AdminSheikhTeacherDto(long Id, string NameArabic, string? DescriptionArabic, short DisplayOrder);
public sealed record AdminSheikhHighlightCardDto(long Id, string TitleArabic, string? BodyArabic, string? ImageUrl, short DisplayOrder);

public sealed class GetAdminSheikhQueryHandler : IRequestHandler<GetAdminSheikhQuery, AdminSheikhDto?>
{
    private readonly ISheikhRepository _sheikhRepository;

    public GetAdminSheikhQueryHandler(ISheikhRepository sheikhRepository)
    {
        _sheikhRepository = sheikhRepository;
    }

    public async Task<AdminSheikhDto?> Handle(GetAdminSheikhQuery request, CancellationToken cancellationToken)
    {
        var sheikh = await _sheikhRepository.GetAdminAggregateAsync(cancellationToken);
        if (sheikh is null)
        {
            return null;
        }

        return new AdminSheikhDto(
            sheikh.Id,
            sheikh.Slug,
            sheikh.DisplayNameArabic,
            sheikh.DisplayNameEnglish,
            sheikh.FullNameArabic,
            sheikh.BirthDate,
            sheikh.BirthPlaceArabic,
            sheikh.BiographyArabic,
            sheikh.ShortDescriptionArabic,
            sheikh.ProfileImageUrl,
            sheikh.HeroImageUrl,
            sheikh.HeroTitleArabic,
            sheikh.HeroSubtitleArabic,
            sheikh.IsActive,
            sheikh.EducationEntries
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new AdminSheikhEducationDto(x.Id, x.TitleArabic, x.InstitutionArabic, x.DescriptionArabic, x.DisplayOrder))
                .ToList(),
            sheikh.ExperienceEntries
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new AdminSheikhExperienceDto(x.Id, x.TitleArabic, x.DescriptionArabic, x.DisplayOrder))
                .ToList(),
            sheikh.Teachers
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new AdminSheikhTeacherDto(x.Id, x.NameArabic, x.DescriptionArabic, x.DisplayOrder))
                .ToList(),
            sheikh.HighlightCards
                .OrderBy(x => x.DisplayOrder)
                .Select(x => new AdminSheikhHighlightCardDto(x.Id, x.TitleArabic, x.BodyArabic, x.ImageUrl, x.DisplayOrder))
                .ToList());
    }
}
