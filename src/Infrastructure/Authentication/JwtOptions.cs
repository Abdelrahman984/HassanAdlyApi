namespace HassanAdly.Infrastructure.Authentication;

public sealed class JwtOptions
{
    public string Issuer { get; init; } = "HassanAdly.Api";
    public string Audience { get; init; } = "HassanAdly.Api";
    public string SigningKey { get; init; } = string.Empty;
    public int AccessTokenLifetimeMinutes { get; init; } = 60;
}
