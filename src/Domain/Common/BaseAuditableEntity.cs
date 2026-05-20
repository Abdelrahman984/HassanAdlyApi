namespace HassanAdly.Domain.Common;

public abstract class BaseAuditableEntity<TKey> : BaseEntity<TKey>
{
    public DateTimeOffset CreatedAtUtc { get; set; }

    public DateTimeOffset UpdatedAtUtc { get; set; }
}

public abstract class BaseAuditableEntity : BaseAuditableEntity<long>
{
}
