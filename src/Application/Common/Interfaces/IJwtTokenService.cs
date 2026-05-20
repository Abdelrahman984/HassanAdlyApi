using HassanAdly.Application.Common.Models;
using HassanAdly.Domain.Entities;

namespace HassanAdly.Application.Common.Interfaces;

public interface IJwtTokenService
{
    JwtTokenResult CreateAdminAccessToken(AdminUser adminUser);
}
