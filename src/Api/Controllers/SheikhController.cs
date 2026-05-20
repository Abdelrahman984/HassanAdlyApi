using HassanAdly.Application.Catalog.Queries.GetSheikh;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Route("api/v1/sheikh")]
public sealed class SheikhController : ControllerBase
{
    private readonly ISender _sender;

    public SheikhController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<SheikhDto>> Get(CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new GetSheikhQuery(), cancellationToken);
        if (dto is null)
        {
            return NotFound();
        }

        return Ok(dto);
    }
}
