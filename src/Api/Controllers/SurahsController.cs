using HassanAdly.Application.Catalog.Queries.GetSurahDetails;
using HassanAdly.Application.Catalog.Queries.GetSurahs;
using HassanAdly.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Route("api/v1/surahs")]
public sealed class SurahsController : ControllerBase
{
    private readonly ISender _sender;

    public SurahsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<SurahListItemDto>>> GetList(
        [FromQuery] string? search,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 20,
        [FromQuery] bool publishedOnly = true,
        CancellationToken cancellationToken = default)
    {
        var vm = await _sender.Send(new GetSurahsQuery(search, page, pageSize, publishedOnly), cancellationToken);
        return Ok(vm);
    }

    [HttpGet("{surahId:int}")]
    public async Task<ActionResult<SurahDetailsDto>> GetById(short surahId, CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new GetSurahDetailsQuery(surahId), cancellationToken);
        if (dto is null)
        {
            return NotFound();
        }

        return Ok(dto);
    }
}
