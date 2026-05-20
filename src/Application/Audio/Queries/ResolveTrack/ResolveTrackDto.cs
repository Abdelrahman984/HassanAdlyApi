namespace HassanAdly.Application.Audio.Queries.ResolveTrack;

public sealed record ResolveTrackDto(
    long Id,
    short SurahId,
    string SurahNameArabic,
    short QiraaId,
    string QiraaNameArabic,
    int DurationSeconds,
    string StreamUrl,
    string DownloadUrl,
    int BitrateKbps,
    long FileSizeBytes);
