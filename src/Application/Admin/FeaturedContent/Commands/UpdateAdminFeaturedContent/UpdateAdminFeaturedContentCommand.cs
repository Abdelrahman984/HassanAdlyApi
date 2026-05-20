using FluentValidation;
using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.FeaturedContent.Commands.UpdateAdminFeaturedContent;

public sealed record UpdateAdminFeaturedContentCommand(
    long FeaturedContentId,
    string TitleArabic,
    string? SubtitleArabic,
    string? ImageUrl,
    string? LinkUrl,
    short DisplayOrder,
    bool IsPublished) : IRequest<bool>;

public sealed class UpdateAdminFeaturedContentCommandValidator : AbstractValidator<UpdateAdminFeaturedContentCommand>
{
    public UpdateAdminFeaturedContentCommandValidator()
    {
        RuleFor(x => x.FeaturedContentId).GreaterThan(0);
        RuleFor(x => x.TitleArabic).NotEmpty().MaximumLength(600);
        RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo((short)0);
    }
}

public sealed class UpdateAdminFeaturedContentCommandHandler : IRequestHandler<UpdateAdminFeaturedContentCommand, bool>
{
    private readonly IFeaturedContentRepository _featuredContentRepository;

    public UpdateAdminFeaturedContentCommandHandler(IFeaturedContentRepository featuredContentRepository)
    {
        _featuredContentRepository = featuredContentRepository;
    }

    public async Task<bool> Handle(UpdateAdminFeaturedContentCommand request, CancellationToken cancellationToken)
    {
        var item = await _featuredContentRepository.GetByIdAsync(request.FeaturedContentId, cancellationToken);
        if (item is null)
        {
            return false;
        }

        item.TitleArabic = request.TitleArabic.Trim();
        item.SubtitleArabic = string.IsNullOrWhiteSpace(request.SubtitleArabic) ? null : request.SubtitleArabic.Trim();
        item.ImageUrl = string.IsNullOrWhiteSpace(request.ImageUrl) ? null : request.ImageUrl.Trim();
        item.LinkUrl = string.IsNullOrWhiteSpace(request.LinkUrl) ? null : request.LinkUrl.Trim();
        item.DisplayOrder = request.DisplayOrder;
        item.IsPublished = request.IsPublished;

        await _featuredContentRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
