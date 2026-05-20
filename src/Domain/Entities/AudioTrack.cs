using HassanAdly.Domain.Enums;

namespace HassanAdly.Domain.Entities;

public class AudioTrack : BaseAuditableEntity<long>
{
    public required long SheikhId { get; set; }
    public required short SurahId { get; set; }
    public required short QiraaId { get; set; }

    public required string TitleArabic { get; set; }
    public required string AudioObjectKey { get; set; }
    public int DurationSeconds { get; set; }
    public long FileSizeBytes { get; set; }
    public int BitrateKbps { get; set; }
    public string? Format { get; set; }
    public string? Checksum { get; set; }
    public int Version { get; set; } = 1;

    public AudioTrackStatus Status { get; set; } = AudioTrackStatus.Draft;

    public Sheikh? Sheikh { get; set; }
    public Surah? Surah { get; set; }
    public Qiraa? Qiraa { get; set; }
    public ICollection<AyahTiming> AyahTimings { get; set; } = new List<AyahTiming>();
}
