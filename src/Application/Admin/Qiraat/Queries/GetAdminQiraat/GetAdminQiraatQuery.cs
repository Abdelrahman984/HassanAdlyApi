using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Qiraat.Queries.GetAdminQiraat;

public sealed record GetAdminQiraatQuery() : IRequest<IReadOnlyList<AdminQiraaDto>>;

public sealed record AdminQiraaDto(
    short Id,
    string Slug,
    string NameArabic,
    string? NameEnglish,
    string RawiArabic,
    string? ImamArabic,
    string? DescriptionArabic,
    short DisplayOrder,
    bool IsPublished);

public sealed class GetAdminQiraatQueryHandler : IRequestHandler<GetAdminQiraatQuery, IReadOnlyList<AdminQiraaDto>>
{
    private readonly IQiraaRepository _qiraaRepository;

    public GetAdminQiraatQueryHandler(IQiraaRepository qiraaRepository)
    {
        _qiraaRepository = qiraaRepository;
    }

    public async Task<IReadOnlyList<AdminQiraaDto>> Handle(GetAdminQiraatQuery request, CancellationToken cancellationToken)
    {
        var qiraat = await _qiraaRepository.GetAllAsync(cancellationToken);
        return qiraat
            .Select(x => new AdminQiraaDto(
                x.Id,
                x.Slug,
                x.NameArabic,
                x.NameEnglish,
                x.RawiArabic,
                x.ImamArabic,
                x.DescriptionArabic,
                x.DisplayOrder,
                x.IsPublished))
            .ToList();
    }
}
