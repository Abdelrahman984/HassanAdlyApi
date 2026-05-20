namespace HassanAdly.Domain.Entities;

public class MediaAsset : BaseAuditableEntity<long>
{
    public required string ObjectKey { get; set; }
    public string? PublicUrl { get; set; }
    public string? ContentType { get; set; }
    public long SizeBytes { get; set; }
}
