using HassanAdly.Application.Admin.Dashboard.Queries.GetAdminDashboard;
using HassanAdly.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.MediaAdmin}")]
[Route("api/v1/admin/dashboard")]
public sealed class AdminDashboardController : ControllerBase
{
    private readonly ISender _sender;

    public AdminDashboardController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<AdminDashboardDto>> Get(CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new GetAdminDashboardQuery(), cancellationToken);
        return Ok(dto);
    }
}
