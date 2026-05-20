namespace HassanAdly.Domain.Entities;

public class FeaturedContent : BaseAuditableEntity<long>
{
    public required string TitleArabic { get; set; }
    public string? SubtitleArabic { get; set; }
    public string? ImageUrl { get; set; }
    public string? LinkUrl { get; set; }
    public short DisplayOrder { get; set; }
    public bool IsPublished { get; set; }
}
