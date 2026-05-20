namespace HassanAdly.Domain.Entities;

public class AyahTiming : BaseAuditableEntity<long>
{
    public required long AudioTrackId { get; set; }
    public required long AyahId { get; set; }
    public required int StartTimeMs { get; set; }
    public required int EndTimeMs { get; set; }

    public AudioTrack? AudioTrack { get; set; }
    public Ayah? Ayah { get; set; }
}
