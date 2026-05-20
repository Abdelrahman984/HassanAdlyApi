using HassanAdly.Application.Admin.Qiraat.Commands.UpdateAdminQiraa;
using HassanAdly.Application.Admin.Qiraat.Queries.GetAdminQiraat;
using HassanAdly.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.ContentAdmin}")]
[Route("api/v1/admin/qiraat")]
public sealed class AdminQiraatController : ControllerBase
{
    private readonly ISender _sender;

    public AdminQiraatController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AdminQiraaDto>>> GetList(CancellationToken cancellationToken)
    {
        var items = await _sender.Send(new GetAdminQiraatQuery(), cancellationToken);
        return Ok(items);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(short id, [FromBody] UpdateAdminQiraaRequest request, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new UpdateAdminQiraaCommand(
            id,
            request.Slug,
            request.NameArabic,
            request.NameEnglish,
            request.RawiArabic,
            request.ImamArabic,
            request.DescriptionArabic,
            request.DisplayOrder,
            request.IsPublished), cancellationToken);

        return ok ? NoContent() : NotFound();
    }
}

public sealed record UpdateAdminQiraaRequest(
    string Slug,
    string NameArabic,
    string? NameEnglish,
    string RawiArabic,
    string? ImamArabic,
    string? DescriptionArabic,
    short DisplayOrder,
    bool IsPublished);
