using HassanAdly.Application.Admin.Tracks.Commands.ArchiveTrack;
using HassanAdly.Application.Admin.Tracks.Commands.CreateAdminTrack;
using HassanAdly.Application.Admin.Tracks.Commands.FinalizeTrackUpload;
using HassanAdly.Application.Admin.Tracks.Commands.InitTrackUpload;
using HassanAdly.Application.Admin.Tracks.Commands.PublishTrack;
using HassanAdly.Application.Admin.Tracks.Commands.UpdateAdminTrack;
using HassanAdly.Application.Admin.Tracks.Dtos;
using HassanAdly.Application.Admin.Tracks.Queries.GetAdminTrackById;
using HassanAdly.Application.Admin.Tracks.Queries.GetAdminTracks;
using HassanAdly.Application.Common.Models;
using HassanAdly.Domain.Constants;
using HassanAdly.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.MediaAdmin}")]
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
        [FromQuery] string? search = null,
        [FromQuery] AudioTrackStatus? status = null,
        [FromQuery] short? surahId = null,
        [FromQuery] short? qiraaId = null,
        CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(new GetAdminTracksQuery(page, pageSize, search, status, surahId, qiraaId), cancellationToken);
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

    [HttpPost]
    public async Task<ActionResult<long>> Create([FromBody] CreateAdminTrackRequest request, CancellationToken cancellationToken)
    {
        var id = await _sender.Send(new CreateAdminTrackCommand(
            request.SheikhId,
            request.SurahId,
            request.QiraaId,
            request.TitleArabic,
            request.DurationSeconds,
            request.FileSizeBytes,
            request.BitrateKbps,
            request.AudioObjectKey,
            request.Format,
            request.Checksum,
            request.Version,
            request.Status), cancellationToken);

        return Ok(id);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateAdminTrackRequest request, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new UpdateAdminTrackCommand(
            id,
            request.TitleArabic,
            request.DurationSeconds,
            request.FileSizeBytes,
            request.BitrateKbps,
            request.AudioObjectKey,
            request.Format,
            request.Checksum,
            request.Version,
            request.Status), cancellationToken);

        return ok ? NoContent() : NotFound();
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

public sealed record CreateAdminTrackRequest(
    long SheikhId,
    short SurahId,
    short QiraaId,
    string TitleArabic,
    int DurationSeconds,
    long FileSizeBytes,
    int BitrateKbps,
    string AudioObjectKey,
    string? Format,
    string? Checksum,
    int Version,
    AudioTrackStatus Status);

public sealed record UpdateAdminTrackRequest(
    string TitleArabic,
    int DurationSeconds,
    long FileSizeBytes,
    int BitrateKbps,
    string AudioObjectKey,
    string? Format,
    string? Checksum,
    int Version,
    AudioTrackStatus Status);
