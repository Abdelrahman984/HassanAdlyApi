namespace HassanAdly.Application.Catalog.Queries.GetSheikh;

public sealed record SheikhDto(
    long Id,
    string Slug,
    string DisplayNameArabic,
    string FullNameArabic,
    string ShortDescriptionArabic,
    string ProfileImageUrl,
    SheikhAboutDto About);

public sealed record SheikhAboutDto(
    DateOnly? BirthDate,
    string? BirthPlaceArabic,
    string BiographyArabic);
