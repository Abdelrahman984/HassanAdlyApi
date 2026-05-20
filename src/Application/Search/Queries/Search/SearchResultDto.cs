namespace HassanAdly.Application.Search.Queries.Search;

public sealed record SearchResultDto(
    string Query,
    IReadOnlyList<SearchSurahDto> Surahs,
    IReadOnlyList<SearchQiraaDto> Qiraat,
    IReadOnlyList<SearchSheikhDto> Sheikh);

public sealed record SearchSurahDto(
    short Id,
    string NameArabic,
    string NameTransliteration);

public sealed record SearchQiraaDto(
    short Id,
    string NameArabic,
    string RawiArabic);

public sealed record SearchSheikhDto(
    long Id,
    string DisplayNameArabic);
