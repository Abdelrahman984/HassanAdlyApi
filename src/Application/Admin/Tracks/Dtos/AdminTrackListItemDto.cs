using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Admin.Tracks.Dtos;

public sealed record AdminTrackListItemDto(
    long Id,
    long SheikhId,
    short SurahId,
    short QiraaId,
    string TitleArabic,
    AudioTrackStatus Status,
    int DurationSeconds,
    int Version);
