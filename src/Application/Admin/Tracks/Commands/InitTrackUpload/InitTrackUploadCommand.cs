using HassanAdly.Application.Admin.Tracks.Dtos;
using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Commands.InitTrackUpload;

public sealed record InitTrackUploadCommand(long AudioTrackId) : IRequest<InitUploadDto>;

public sealed class InitTrackUploadCommandHandler : IRequestHandler<InitTrackUploadCommand, InitUploadDto>
{
    private readonly IUploadFlowService _uploadFlowService;

    public InitTrackUploadCommandHandler(IUploadFlowService uploadFlowService)
    {
        _uploadFlowService = uploadFlowService;
    }

    public Task<InitUploadDto> Handle(InitTrackUploadCommand request, CancellationToken cancellationToken)
    {
        return _uploadFlowService.InitTrackUploadAsync(request.AudioTrackId, cancellationToken);
    }
}
