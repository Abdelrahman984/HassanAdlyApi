namespace HassanAdly.Domain.Entities;

public class SheikhExperience : BaseAuditableEntity<long>
{
    public required long SheikhId { get; set; }
    public required string TitleArabic { get; set; }
    public string? DescriptionArabic { get; set; }
    public short DisplayOrder { get; set; }

    public Sheikh? Sheikh { get; set; }
}
