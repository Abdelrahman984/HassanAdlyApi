using HassanAdly.Application.Search.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Route("api/v1/search")]
public sealed class SearchController : ControllerBase
{
    private readonly ISender _sender;

    public SearchController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<SearchResultDto>> Search([FromQuery(Name = "q")] string q, CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new SearchQuery(q), cancellationToken);
        return Ok(dto);
    }
}
