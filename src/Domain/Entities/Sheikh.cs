namespace HassanAdly.Domain.Entities;

public class Sheikh : BaseAuditableEntity<long>
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
    public bool IsActive { get; set; }

    public ICollection<AudioTrack> AudioTracks { get; set; } = new List<AudioTrack>();
}
