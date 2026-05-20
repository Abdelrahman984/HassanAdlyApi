using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Catalog.Queries.GetSurahs;

public sealed record SurahListItemDto(
    short Id,
    string NameArabic,
    string NameTransliteration,
    RevelationType RevelationType,
    short VerseCount,
    int AvailableQiraatCount);
