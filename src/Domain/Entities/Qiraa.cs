namespace HassanAdly.Domain.Entities;

public class Qiraa : BaseAuditableEntity<short>
{
    public required string Slug { get; set; }
    public required string NameArabic { get; set; }
    public string? NameEnglish { get; set; }
    public required string RawiArabic { get; set; }
    public string? ImamArabic { get; set; }
    public string? DescriptionArabic { get; set; }
    public short DisplayOrder { get; set; }
    public bool IsPublished { get; set; }

    public ICollection<AudioTrack> AudioTracks { get; set; } = new List<AudioTrack>();
}
