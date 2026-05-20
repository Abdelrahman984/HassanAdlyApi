using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Enums;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Commands.PublishTrack;

public sealed record PublishTrackCommand(long AudioTrackId) : IRequest<bool>;

public sealed class PublishTrackCommandHandler : IRequestHandler<PublishTrackCommand, bool>
{
    private readonly IAudioTrackRepository _audioTrackRepository;

    public PublishTrackCommandHandler(IAudioTrackRepository audioTrackRepository)
    {
        _audioTrackRepository = audioTrackRepository;
    }

    public Task<bool> Handle(PublishTrackCommand request, CancellationToken cancellationToken)
    {
        return _audioTrackRepository.UpdateStatusAsync(request.AudioTrackId, AudioTrackStatus.Published, cancellationToken);
    }
}
