namespace HassanAdly.Domain.Entities;

public class Sheikh : BaseEntity<long>
{
    public required string Slug { get; set; }
    public required string DisplayNameArabic { get; set; }
    public string? DisplayNameEnglish { get; set; }
    public required string FullNameArabic { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string? BirthPlaceArabic { get; set; }
    public required string BiographyArabic { get; set; }
    public required string ShortDescriptionArabic { get; set; }
    public required string ProfileImageUrl { get; set; }
    public string? HeroImageUrl { get; set; }
    public string? HeroTitleArabic { get; set; }
    public string? HeroSubtitleArabic { get; set; }
    public bool IsActive { get; set; }

    public ICollection<AudioTrack> AudioTracks { get; set; } = new List<AudioTrack>();
    public ICollection<SheikhEducation> EducationEntries { get; set; } = new List<SheikhEducation>();
    public ICollection<SheikhExperience> ExperienceEntries { get; set; } = new List<SheikhExperience>();
    public ICollection<SheikhTeacher> Teachers { get; set; } = new List<SheikhTeacher>();
    public ICollection<SheikhHighlightCard> HighlightCards { get; set; } = new List<SheikhHighlightCard>();
}
