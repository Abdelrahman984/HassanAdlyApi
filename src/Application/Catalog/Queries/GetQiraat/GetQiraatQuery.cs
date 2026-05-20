using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Catalog.Queries.GetQiraat;

public sealed record GetQiraatQuery(bool PublishedOnly = true) : IRequest<IReadOnlyList<QiraaDto>>;

public sealed class GetQiraatQueryHandler : IRequestHandler<GetQiraatQuery, IReadOnlyList<QiraaDto>>
{
    private readonly IQiraaRepository _qiraaRepository;

    public GetQiraatQueryHandler(IQiraaRepository qiraaRepository)
    {
        _qiraaRepository = qiraaRepository;
    }

    public async Task<IReadOnlyList<QiraaDto>> Handle(GetQiraatQuery request, CancellationToken cancellationToken)
    {
        var qiraat = await _qiraaRepository.GetListAsync(request.PublishedOnly, cancellationToken);

        return qiraat
            .OrderBy(q => q.DisplayOrder)
            .Select(q => new QiraaDto(q.Id, q.Slug, q.NameArabic, q.RawiArabic))
            .ToList();
    }
}
