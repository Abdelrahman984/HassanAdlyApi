using HassanAdly.Application.Admin.FeaturedContent.Commands.UpdateAdminFeaturedContent;
using HassanAdly.Application.Admin.FeaturedContent.Queries.GetAdminFeaturedContents;
using HassanAdly.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.ContentAdmin}")]
[Route("api/v1/admin/featured-content")]
public sealed class AdminFeaturedContentController : ControllerBase
{
    private readonly ISender _sender;

    public AdminFeaturedContentController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AdminFeaturedContentDto>>> GetList(CancellationToken cancellationToken)
    {
        var items = await _sender.Send(new GetAdminFeaturedContentsQuery(), cancellationToken);
        return Ok(items);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateAdminFeaturedContentRequest request, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new UpdateAdminFeaturedContentCommand(
            id,
            request.TitleArabic,
            request.SubtitleArabic,
            request.ImageUrl,
            request.LinkUrl,
            request.DisplayOrder,
            request.IsPublished), cancellationToken);

        return ok ? NoContent() : NotFound();
    }
}

public sealed record UpdateAdminFeaturedContentRequest(
    string TitleArabic,
    string? SubtitleArabic,
    string? ImageUrl,
    string? LinkUrl,
    short DisplayOrder,
    bool IsPublished);
