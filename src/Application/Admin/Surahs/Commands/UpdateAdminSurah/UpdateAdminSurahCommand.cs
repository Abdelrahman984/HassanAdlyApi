using FluentValidation;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Enums;
using MediatR;

namespace HassanAdly.Application.Admin.Surahs.Commands.UpdateAdminSurah;

public sealed record UpdateAdminSurahCommand(
    short SurahId,
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
    bool IsPublished) : IRequest<bool>;

public sealed class UpdateAdminSurahCommandValidator : AbstractValidator<UpdateAdminSurahCommand>
{
    public UpdateAdminSurahCommandValidator()
    {
        RuleFor(x => x.SurahId).GreaterThan((short)0);
        RuleFor(x => x.NameArabic).NotEmpty().MaximumLength(400);
        RuleFor(x => x.NameTransliteration).NotEmpty().MaximumLength(200);
        RuleFor(x => x.VerseCount).GreaterThan((short)0);
        RuleFor(x => x.DisplayOrder).GreaterThan((short)0);
        RuleFor(x => x.RevelationType).NotEmpty();
    }
}

public sealed class UpdateAdminSurahCommandHandler : IRequestHandler<UpdateAdminSurahCommand, bool>
{
    private readonly ISurahRepository _surahRepository;

    public UpdateAdminSurahCommandHandler(ISurahRepository surahRepository)
    {
        _surahRepository = surahRepository;
    }

    public async Task<bool> Handle(UpdateAdminSurahCommand request, CancellationToken cancellationToken)
    {
        var surah = await _surahRepository.GetByIdAsync(request.SurahId, cancellationToken);
        if (surah is null)
        {
            return false;
        }

        if (!Enum.TryParse<RevelationType>(request.RevelationType, ignoreCase: true, out var revelationType))
        {
            throw new ValidationException($"Unsupported revelation type '{request.RevelationType}'.");
        }

        surah.NameArabic = request.NameArabic.Trim();
        surah.NameTransliteration = request.NameTransliteration.Trim();
        surah.NameEnglish = string.IsNullOrWhiteSpace(request.NameEnglish) ? null : request.NameEnglish.Trim();
        surah.SeoTitleArabic = string.IsNullOrWhiteSpace(request.SeoTitleArabic) ? null : request.SeoTitleArabic.Trim();
        surah.SeoDescriptionArabic = string.IsNullOrWhiteSpace(request.SeoDescriptionArabic) ? null : request.SeoDescriptionArabic.Trim();
        surah.SeoTitleEnglish = string.IsNullOrWhiteSpace(request.SeoTitleEnglish) ? null : request.SeoTitleEnglish.Trim();
        surah.SeoDescriptionEnglish = string.IsNullOrWhiteSpace(request.SeoDescriptionEnglish) ? null : request.SeoDescriptionEnglish.Trim();
        surah.RevelationType = revelationType;
        surah.VerseCount = request.VerseCount;
        surah.DisplayOrder = request.DisplayOrder;
        surah.IsPublished = request.IsPublished;
        surah.SearchNormalizedArabic = request.NameArabic.Trim();

        await _surahRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
