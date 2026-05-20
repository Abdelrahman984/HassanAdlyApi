using HassanAdly.Domain.Enums;

namespace HassanAdly.Application.Admin.RecordingMatrix.Queries.GetRecordingMatrix;

public sealed record RecordingMatrixDto(
    IReadOnlyList<RecordingMatrixSurahDto> Surahs,
    IReadOnlyList<RecordingMatrixQiraaDto> Qiraat);

public sealed record RecordingMatrixSurahDto(
    short Id,
    string NameArabic,
    IReadOnlyList<RecordingMatrixCellDto> Cells);

public sealed record RecordingMatrixQiraaDto(
    short Id,
    string NameArabic);

public sealed record RecordingMatrixCellDto(
    short QiraaId,
    AudioTrackStatus Status,
    long? AudioTrackId);
