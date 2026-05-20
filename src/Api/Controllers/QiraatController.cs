using HassanAdly.Application.Catalog.Queries.GetQiraat;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Route("api/v1/qiraat")]
public sealed class QiraatController : ControllerBase
{
    private readonly ISender _sender;

    public QiraatController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<QiraaDto>>> GetList([FromQuery] bool publishedOnly = true, CancellationToken cancellationToken = default)
    {
        var items = await _sender.Send(new GetQiraatQuery(publishedOnly), cancellationToken);
        return Ok(items);
    }
}
