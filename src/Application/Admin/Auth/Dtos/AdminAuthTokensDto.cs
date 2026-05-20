namespace HassanAdly.Application.Admin.Auth.Dtos;

public sealed record AdminAuthTokensDto(
    string AccessToken,
    DateTimeOffset AccessTokenExpiresAtUtc,
    string RefreshToken);
