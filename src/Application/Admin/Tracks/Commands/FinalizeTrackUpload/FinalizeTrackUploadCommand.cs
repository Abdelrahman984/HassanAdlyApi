using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Commands.FinalizeTrackUpload;

public sealed record FinalizeTrackUploadCommand(long AudioTrackId) : IRequest<bool>;

public sealed class FinalizeTrackUploadCommandHandler : IRequestHandler<FinalizeTrackUploadCommand, bool>
{
    private readonly IUploadFlowService _uploadFlowService;

    public FinalizeTrackUploadCommandHandler(IUploadFlowService uploadFlowService)
    {
        _uploadFlowService = uploadFlowService;
    }

    public Task<bool> Handle(FinalizeTrackUploadCommand request, CancellationToken cancellationToken)
    {
        return _uploadFlowService.FinalizeTrackUploadAsync(request.AudioTrackId, cancellationToken);
    }
}
