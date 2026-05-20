using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.RecordingMatrix.Queries.GetRecordingMatrix;

public sealed record GetRecordingMatrixQuery : IRequest<RecordingMatrixDto>;

public sealed class GetRecordingMatrixQueryHandler : IRequestHandler<GetRecordingMatrixQuery, RecordingMatrixDto>
{
    private readonly IRecordingMatrixQueryService _recordingMatrixQueryService;

    public GetRecordingMatrixQueryHandler(IRecordingMatrixQueryService recordingMatrixQueryService)
    {
        _recordingMatrixQueryService = recordingMatrixQueryService;
    }

    public Task<RecordingMatrixDto> Handle(GetRecordingMatrixQuery request, CancellationToken cancellationToken)
    {
        return _recordingMatrixQueryService.GetAsync(cancellationToken);
    }
}
