namespace HassanAdly.Domain.Entities;

public class AdminRefreshToken : BaseAuditableEntity<long>
{
    public required long AdminUserId { get; set; }
    public required string TokenHash { get; set; }
    public required DateTimeOffset ExpiresAtUtc { get; set; }
    public DateTimeOffset? RevokedAtUtc { get; set; }

    public AdminUser? AdminUser { get; set; }
}
