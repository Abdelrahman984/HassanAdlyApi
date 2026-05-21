using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HassanAdly.Application.Admin.Auth.Commands.AdminLogin;
using HassanAdly.Application.Admin.Auth.Commands.AdminLogout;
using HassanAdly.Application.Admin.Auth.Commands.AdminRefresh;
using HassanAdly.Application.Admin.Auth.Dtos;
using HassanAdly.Application.Admin.Auth.Queries.AdminMe;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Route("api/v1/admin/auth")]
public sealed class AdminAuthController : ControllerBase
{
    private readonly ISender _sender;

    public AdminAuthController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AdminAuthTokensDto>> Login([FromBody] AdminLoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new AdminLoginCommand(request.Email, request.Password), cancellationToken);
        if (result is null)
        {
            return Unauthorized();
        }

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("refresh")]
    public async Task<ActionResult<AdminAuthTokensDto>> Refresh([FromBody] AdminRefreshRequest request, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new AdminRefreshCommand(request.RefreshToken), cancellationToken);
        if (result is null)
        {
            return Unauthorized();
        }

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] AdminLogoutRequest request, CancellationToken cancellationToken)
    {
        await _sender.Send(new AdminLogoutCommand(request.RefreshToken), cancellationToken);
        return NoContent();
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<ActionResult<AdminMeDto>> Me(CancellationToken cancellationToken)
    {
        var sub = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value
            ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!long.TryParse(sub, out var adminUserId))
        {
            return Unauthorized();
        }

        var dto = await _sender.Send(new AdminMeQuery(adminUserId), cancellationToken);
        if (dto is null)
        {
            return Unauthorized();
        }

        return Ok(dto);
    }
}

public sealed record AdminLoginRequest(string Email, string Password);
public sealed record AdminRefreshRequest(string RefreshToken);
public sealed record AdminLogoutRequest(string RefreshToken);
