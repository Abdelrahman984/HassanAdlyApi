using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Admin.Tracks.Dtos;

public sealed record AdminTrackListItemDto(
    long Id,
    long SheikhId,
    string SheikhDisplayNameArabic,
    short SurahId,
    string SurahNameArabic,
    short QiraaId,
    string QiraaNameArabic,
    string TitleArabic,
    AudioTrackStatus Status,
    int DurationSeconds,
    int Version);
