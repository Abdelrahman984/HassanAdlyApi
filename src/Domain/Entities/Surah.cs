using HassanAdly.Domain.Enums;

namespace HassanAdly.Domain.Entities;

public class Surah : BaseAuditableEntity<short>
{
    public required string NameArabic { get; set; }
    public required string NameTransliteration { get; set; }
    public string? NameEnglish { get; set; }
    public string? SeoTitleArabic { get; set; }
    public string? SeoDescriptionArabic { get; set; }
    public string? SeoTitleEnglish { get; set; }
    public string? SeoDescriptionEnglish { get; set; }
    public RevelationType RevelationType { get; set; }
    public short VerseCount { get; set; }
    public short DisplayOrder { get; set; }
    public required string SearchNormalizedArabic { get; set; }
    public bool IsPublished { get; set; }

    public ICollection<AudioTrack> AudioTracks { get; set; } = new List<AudioTrack>();
    public ICollection<Ayah> Ayat { get; set; } = new List<Ayah>();
}
