namespace HassanAdly.Application.Common.Models;

public sealed record JwtTokenResult(
    string AccessToken,
    DateTimeOffset ExpiresAtUtc);
