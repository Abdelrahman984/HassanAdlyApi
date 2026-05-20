using HassanAdly.Application.Admin.Sheikh.Commands.UpdateAdminSheikh;
using HassanAdly.Application.Admin.Sheikh.Queries.GetAdminSheikh;
using HassanAdly.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HassanAdly.Api.Controllers;

[ApiController]
[Authorize(Roles = $"{Roles.SuperAdmin},{Roles.ContentAdmin}")]
[Route("api/v1/admin/sheikh")]
public sealed class AdminSheikhController : ControllerBase
{
    private readonly ISender _sender;

    public AdminSheikhController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<AdminSheikhDto>> Get(CancellationToken cancellationToken)
    {
        var dto = await _sender.Send(new GetAdminSheikhQuery(), cancellationToken);
        if (dto is null)
        {
            return NotFound();
        }

        return Ok(dto);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateAdminSheikhRequest request, CancellationToken cancellationToken)
    {
        var ok = await _sender.Send(new UpdateAdminSheikhCommand(
            id,
            request.Slug,
            request.DisplayNameArabic,
            request.DisplayNameEnglish,
            request.FullNameArabic,
            request.BirthDate,
            request.BirthPlaceArabic,
            request.BiographyArabic,
            request.ShortDescriptionArabic,
            request.ProfileImageUrl,
            request.HeroImageUrl,
            request.HeroTitleArabic,
            request.HeroSubtitleArabic,
            request.IsActive,
            request.EducationEntries,
            request.ExperienceEntries,
            request.Teachers,
            request.HighlightCards), cancellationToken);

        return ok ? NoContent() : NotFound();
    }
}

public sealed record UpdateAdminSheikhRequest(
    string Slug,
    string DisplayNameArabic,
    string? DisplayNameEnglish,
    string FullNameArabic,
    DateOnly? BirthDate,
    string? BirthPlaceArabic,
    string BiographyArabic,
    string ShortDescriptionArabic,
    string ProfileImageUrl,
    string? HeroImageUrl,
    string? HeroTitleArabic,
    string? HeroSubtitleArabic,
    bool IsActive,
    IReadOnlyList<UpdateAdminSheikhEducationItem> EducationEntries,
    IReadOnlyList<UpdateAdminSheikhExperienceItem> ExperienceEntries,
    IReadOnlyList<UpdateAdminSheikhTeacherItem> Teachers,
    IReadOnlyList<UpdateAdminSheikhHighlightCardItem> HighlightCards);
