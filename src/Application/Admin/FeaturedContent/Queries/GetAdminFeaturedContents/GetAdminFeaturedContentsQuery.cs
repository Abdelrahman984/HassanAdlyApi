using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.FeaturedContent.Queries.GetAdminFeaturedContents;

public sealed record GetAdminFeaturedContentsQuery() : IRequest<IReadOnlyList<AdminFeaturedContentDto>>;

public sealed record AdminFeaturedContentDto(
    long Id,
    string TitleArabic,
    string? SubtitleArabic,
    string? ImageUrl,
    string? LinkUrl,
    short DisplayOrder,
    bool IsPublished);

public sealed class GetAdminFeaturedContentsQueryHandler : IRequestHandler<GetAdminFeaturedContentsQuery, IReadOnlyList<AdminFeaturedContentDto>>
{
    private readonly IFeaturedContentRepository _featuredContentRepository;

    public GetAdminFeaturedContentsQueryHandler(IFeaturedContentRepository featuredContentRepository)
    {
        _featuredContentRepository = featuredContentRepository;
    }

    public async Task<IReadOnlyList<AdminFeaturedContentDto>> Handle(GetAdminFeaturedContentsQuery request, CancellationToken cancellationToken)
    {
        var items = await _featuredContentRepository.GetListAsync(cancellationToken);
        return items
            .Select(x => new AdminFeaturedContentDto(
                x.Id,
                x.TitleArabic,
                x.SubtitleArabic,
                x.ImageUrl,
                x.LinkUrl,
                x.DisplayOrder,
                x.IsPublished))
            .ToList();
    }
}
