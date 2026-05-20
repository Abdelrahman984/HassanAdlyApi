using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Catalog.Queries.GetSurahDetails;

public sealed record SurahDetailsDto(
    short Id,
    string NameArabic,
    string NameTransliteration,
    RevelationType RevelationType,
    short VerseCount,
    IReadOnlyList<AvailableQiraaDto> AvailableQiraat);

public sealed record AvailableQiraaDto(
    short Id,
    string NameArabic,
    string RawiArabic,
    long? TrackId,
    int? DurationSeconds,
    bool IsAvailable);
