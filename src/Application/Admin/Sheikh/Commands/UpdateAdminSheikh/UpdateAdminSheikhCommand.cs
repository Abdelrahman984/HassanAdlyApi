using FluentValidation;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using MediatR;

namespace HassanAdly.Application.Admin.Sheikh.Commands.UpdateAdminSheikh;

public sealed record UpdateAdminSheikhCommand(
    long SheikhId,
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
    IReadOnlyList<UpdateAdminSheikhHighlightCardItem> HighlightCards) : IRequest<bool>;

public sealed record UpdateAdminSheikhEducationItem(long Id, string TitleArabic, string? InstitutionArabic, string? DescriptionArabic, short DisplayOrder);
public sealed record UpdateAdminSheikhExperienceItem(long Id, string TitleArabic, string? DescriptionArabic, short DisplayOrder);
public sealed record UpdateAdminSheikhTeacherItem(long Id, string NameArabic, string? DescriptionArabic, short DisplayOrder);
public sealed record UpdateAdminSheikhHighlightCardItem(long Id, string TitleArabic, string? BodyArabic, string? ImageUrl, short DisplayOrder);

public sealed class UpdateAdminSheikhCommandValidator : AbstractValidator<UpdateAdminSheikhCommand>
{
    public UpdateAdminSheikhCommandValidator()
    {
        RuleFor(x => x.SheikhId).GreaterThan(0);
        RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
        RuleFor(x => x.DisplayNameArabic).NotEmpty().MaximumLength(400);
        RuleFor(x => x.FullNameArabic).NotEmpty().MaximumLength(800);
        RuleFor(x => x.BiographyArabic).NotEmpty();
        RuleFor(x => x.ShortDescriptionArabic).NotEmpty().MaximumLength(500);
        RuleFor(x => x.ProfileImageUrl).NotEmpty().MaximumLength(2000);
    }
}

public sealed class UpdateAdminSheikhCommandHandler : IRequestHandler<UpdateAdminSheikhCommand, bool>
{
    private readonly ISheikhRepository _sheikhRepository;

    public UpdateAdminSheikhCommandHandler(ISheikhRepository sheikhRepository)
    {
        _sheikhRepository = sheikhRepository;
    }

    public async Task<bool> Handle(UpdateAdminSheikhCommand request, CancellationToken cancellationToken)
    {
        var sheikh = await _sheikhRepository.GetAdminAggregateAsync(cancellationToken);
        if (sheikh is null || sheikh.Id != request.SheikhId)
        {
            return false;
        }

        sheikh.Slug = request.Slug.Trim();
        sheikh.DisplayNameArabic = request.DisplayNameArabic.Trim();
        sheikh.DisplayNameEnglish = string.IsNullOrWhiteSpace(request.DisplayNameEnglish) ? null : request.DisplayNameEnglish.Trim();
        sheikh.FullNameArabic = request.FullNameArabic.Trim();
        sheikh.BirthDate = request.BirthDate;
        sheikh.BirthPlaceArabic = string.IsNullOrWhiteSpace(request.BirthPlaceArabic) ? null : request.BirthPlaceArabic.Trim();
        sheikh.BiographyArabic = request.BiographyArabic.Trim();
        sheikh.ShortDescriptionArabic = request.ShortDescriptionArabic.Trim();
        sheikh.ProfileImageUrl = request.ProfileImageUrl.Trim();
        sheikh.HeroImageUrl = string.IsNullOrWhiteSpace(request.HeroImageUrl) ? null : request.HeroImageUrl.Trim();
        sheikh.HeroTitleArabic = string.IsNullOrWhiteSpace(request.HeroTitleArabic) ? null : request.HeroTitleArabic.Trim();
        sheikh.HeroSubtitleArabic = string.IsNullOrWhiteSpace(request.HeroSubtitleArabic) ? null : request.HeroSubtitleArabic.Trim();
        sheikh.IsActive = request.IsActive;

        ReplaceEducationEntries(sheikh, request.EducationEntries);
        ReplaceExperienceEntries(sheikh, request.ExperienceEntries);
        ReplaceTeacherEntries(sheikh, request.Teachers);
        ReplaceHighlightCards(sheikh, request.HighlightCards);

        await _sheikhRepository.SaveChangesAsync(cancellationToken);
        return true;
    }

    private static void ReplaceEducationEntries(Domain.Entities.Sheikh sheikh, IReadOnlyList<UpdateAdminSheikhEducationItem> items)
    {
        sheikh.EducationEntries.Clear();
        foreach (var item in items.OrderBy(x => x.DisplayOrder))
        {
            sheikh.EducationEntries.Add(new SheikhEducation
            {
                Id = 0,
                SheikhId = sheikh.Id,
                TitleArabic = item.TitleArabic.Trim(),
                InstitutionArabic = string.IsNullOrWhiteSpace(item.InstitutionArabic) ? null : item.InstitutionArabic.Trim(),
                DescriptionArabic = string.IsNullOrWhiteSpace(item.DescriptionArabic) ? null : item.DescriptionArabic.Trim(),
                DisplayOrder = item.DisplayOrder
            });
        }
    }

    private static void ReplaceExperienceEntries(Domain.Entities.Sheikh sheikh, IReadOnlyList<UpdateAdminSheikhExperienceItem> items)
    {
        sheikh.ExperienceEntries.Clear();
        foreach (var item in items.OrderBy(x => x.DisplayOrder))
        {
            sheikh.ExperienceEntries.Add(new SheikhExperience
            {
                Id = 0,
                SheikhId = sheikh.Id,
                TitleArabic = item.TitleArabic.Trim(),
                DescriptionArabic = string.IsNullOrWhiteSpace(item.DescriptionArabic) ? null : item.DescriptionArabic.Trim(),
                DisplayOrder = item.DisplayOrder
            });
        }
    }

    private static void ReplaceTeacherEntries(Domain.Entities.Sheikh sheikh, IReadOnlyList<UpdateAdminSheikhTeacherItem> items)
    {
        sheikh.Teachers.Clear();
        foreach (var item in items.OrderBy(x => x.DisplayOrder))
        {
            sheikh.Teachers.Add(new SheikhTeacher
            {
                Id = 0,
                SheikhId = sheikh.Id,
                NameArabic = item.NameArabic.Trim(),
                DescriptionArabic = string.IsNullOrWhiteSpace(item.DescriptionArabic) ? null : item.DescriptionArabic.Trim(),
                DisplayOrder = item.DisplayOrder
            });
        }
    }

    private static void ReplaceHighlightCards(Domain.Entities.Sheikh sheikh, IReadOnlyList<UpdateAdminSheikhHighlightCardItem> items)
    {
        sheikh.HighlightCards.Clear();
        foreach (var item in items.OrderBy(x => x.DisplayOrder))
        {
            sheikh.HighlightCards.Add(new SheikhHighlightCard
            {
                Id = 0,
                SheikhId = sheikh.Id,
                TitleArabic = item.TitleArabic.Trim(),
                BodyArabic = string.IsNullOrWhiteSpace(item.BodyArabic) ? null : item.BodyArabic.Trim(),
                ImageUrl = string.IsNullOrWhiteSpace(item.ImageUrl) ? null : item.ImageUrl.Trim(),
                DisplayOrder = item.DisplayOrder
            });
        }
    }
}
