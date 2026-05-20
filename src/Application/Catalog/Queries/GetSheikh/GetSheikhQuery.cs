using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Catalog.Queries.GetSheikh;

public sealed record GetSheikhQuery : IRequest<SheikhDto?>;

public sealed class GetSheikhQueryHandler : IRequestHandler<GetSheikhQuery, SheikhDto?>
{
    private readonly ISheikhRepository _sheikhRepository;

    public GetSheikhQueryHandler(ISheikhRepository sheikhRepository)
    {
        _sheikhRepository = sheikhRepository;
    }

    public async Task<SheikhDto?> Handle(GetSheikhQuery request, CancellationToken cancellationToken)
    {
        var sheikh = await _sheikhRepository.GetActiveAsync(cancellationToken);
        if (sheikh is null)
        {
            return null;
        }

        return new SheikhDto(
            sheikh.Id,
            sheikh.Slug,
            sheikh.DisplayNameArabic,
            sheikh.FullNameArabic,
            sheikh.ShortDescriptionArabic,
            sheikh.ProfileImageUrl,
            new SheikhAboutDto(sheikh.BirthDate, sheikh.BirthPlaceArabic, sheikh.BiographyArabic));
    }
}
