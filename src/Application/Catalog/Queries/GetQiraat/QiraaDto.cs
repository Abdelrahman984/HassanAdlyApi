namespace HassanAdly.Application.Catalog.Queries.GetQiraat;

public sealed record QiraaDto(
    short Id,
    string Slug,
    string NameArabic,
    string RawiArabic);
