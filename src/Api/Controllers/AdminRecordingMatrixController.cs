using HassanAdly.Application.Admin.RecordingMatrix.Queries.GetRecordingMatrix;
using HassanAdly.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.MediaAdmin}")]
[Route("api/v1/admin/recording-matrix")]
public sealed class AdminRecordingMatrixController : ControllerBase
{
    private readonly ISender _sender;

    public AdminRecordingMatrixController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<RecordingMatrixDto>> Get(CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new GetRecordingMatrixQuery(), cancellationToken);
        return Ok(dto);
    }
}
