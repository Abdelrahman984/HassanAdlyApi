namespace HassanAdly.Domain.Entities;

public class SheikhHighlightCard : BaseAuditableEntity<long>
{
    public required long SheikhId { get; set; }
    public required string TitleArabic { get; set; }
    public string? BodyArabic { get; set; }
    public string? ImageUrl { get; set; }
    public short DisplayOrder { get; set; }

    public Sheikh? Sheikh { get; set; }
}
