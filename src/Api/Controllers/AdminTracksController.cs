using HassanAdly.Application.Admin.Tracks.Commands.ArchiveTrack;
using HassanAdly.Application.Admin.Tracks.Commands.FinalizeTrackUpload;
using HassanAdly.Application.Admin.Tracks.Commands.InitTrackUpload;
using HassanAdly.Application.Admin.Tracks.Commands.PublishTrack;
using HassanAdly.Application.Admin.Tracks.Dtos;
using HassanAdly.Application.Admin.Tracks.Queries.GetAdminTrackById;
using HassanAdly.Application.Admin.Tracks.Queries.GetAdminTracks;
using HassanAdly.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/admin/tracks")]
public sealed class AdminTracksController : ControllerBase
{
    private readonly ISender _sender;

    public AdminTracksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<AdminTrackListItemDto>>> GetList(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(new GetAdminTracksQuery(page, pageSize), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<AdminTrackDetailsDto>> GetById(long id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetAdminTrackByIdQuery(id), cancellationToken);
        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("{id:long}/init-upload")]
    public async Task<ActionResult<InitUploadDto>> InitUpload(long id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new InitTrackUploadCommand(id), cancellationToken);
        return Ok(result);
    }

    [HttpPost("{id:long}/finalize-upload")]
    public async Task<IActionResult> FinalizeUpload(long id, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new FinalizeTrackUploadCommand(id), cancellationToken);
        return ok ? Ok() : NotFound();
    }

    [HttpPost("{id:long}/publish")]
    public async Task<IActionResult> Publish(long id, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new PublishTrackCommand(id), cancellationToken);
        return ok ? Ok() : NotFound();
    }

    [HttpPost("{id:long}/archive")]
    public async Task<IActionResult> Archive(long id, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new ArchiveTrackCommand(id), cancellationToken);
        return ok ? Ok() : NotFound();
    }
}
