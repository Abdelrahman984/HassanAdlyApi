using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Application.Common.Models;
using HassanAdly.Domain.Constants;
using HassanAdly.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HassanAdly.Infrastructure.Authentication;

public sealed class JwtTokenService : IJwtTokenService
{
    private readonly JwtOptions _options;
    private readonly TimeProvider _timeProvider;

    public JwtTokenService(IOptions<JwtOptions> options, TimeProvider timeProvider)
    {
        _options = options.Value;
        _timeProvider = timeProvider;
    }

    public JwtTokenResult CreateAdminAccessToken(AdminUser adminUser)
    {
        var now = _timeProvider.GetUtcNow();
        var expiresAt = now.AddMinutes(_options.AccessTokenLifetimeMinutes);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, adminUser.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, adminUser.Email),
            new(ClaimTypes.Role, Roles.SuperAdmin)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            notBefore: now.UtcDateTime,
            expires: expiresAt.UtcDateTime,
            signingCredentials: credentials);

        var encoded = new JwtSecurityTokenHandler().WriteToken(token);
        return new JwtTokenResult(encoded, expiresAt);
    }
}
