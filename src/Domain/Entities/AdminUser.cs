namespace HassanAdly.Domain.Entities;

public class AdminUser : BaseAuditableEntity<long>
{
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string DisplayName { get; set; }
    public required string Role { get; set; }
    public bool IsActive { get; set; } = true;

    public ICollection<AdminRefreshToken> RefreshTokens { get; set; } = new List<AdminRefreshToken>();
}
