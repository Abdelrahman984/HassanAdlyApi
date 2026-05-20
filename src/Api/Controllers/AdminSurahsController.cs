using HassanAdly.Application.Admin.Surahs.Commands.UpdateAdminSurah;
using HassanAdly.Application.Admin.Surahs.Queries.GetAdminSurahs;
using HassanAdly.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.ContentAdmin}")]
[Route("api/v1/admin/surahs")]
public sealed class AdminSurahsController : ControllerBase
{
    private readonly ISender _sender;

    public AdminSurahsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<AdminSurahDto>>> GetList(CancellationToken cancellationToken)
    {
        var items = await _sender.Send(new GetAdminSurahsQuery(), cancellationToken);
        return Ok(items);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(short id, [FromBody] UpdateAdminSurahRequest request, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new UpdateAdminSurahCommand(
            id,
            request.NameArabic,
            request.NameTransliteration,
            request.NameEnglish,
            request.SeoTitleArabic,
            request.SeoDescriptionArabic,
            request.SeoTitleEnglish,
            request.SeoDescriptionEnglish,
            request.RevelationType,
            request.VerseCount,
            request.DisplayOrder,
            request.IsPublished), cancellationToken);

        return ok ? NoContent() : NotFound();
    }
}

public sealed record UpdateAdminSurahRequest(
    string NameArabic,
    string NameTransliteration,
    string? NameEnglish,
    string? SeoTitleArabic,
    string? SeoDescriptionArabic,
    string? SeoTitleEnglish,
    string? SeoDescriptionEnglish,
    string RevelationType,
    short VerseCount,
    short DisplayOrder,
    bool IsPublished);
