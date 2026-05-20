using HassanAdly.Application.Audio.Queries.ResolveTrack;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Route("api/v1/tracks")]
public sealed class TracksController : ControllerBase
{
    private readonly ISender _sender;

    public TracksController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("resolve")]
    public async Task<ActionResult<ResolveTrackDto>> Resolve([FromQuery] short surahId, [FromQuery] short qiraaId, CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new ResolveTrackQuery(surahId, qiraaId), cancellationToken);
        if (dto is null)
        {
            return NotFound();
        }

        return Ok(dto);
    }
}
