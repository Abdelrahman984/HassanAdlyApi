using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Enums;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Commands.ArchiveTrack;

public sealed record ArchiveTrackCommand(long AudioTrackId) : IRequest<bool>;

public sealed class ArchiveTrackCommandHandler : IRequestHandler<ArchiveTrackCommand, bool>
{
    private readonly IAudioTrackRepository _audioTrackRepository;

    public ArchiveTrackCommandHandler(IAudioTrackRepository audioTrackRepository)
    {
        _audioTrackRepository = audioTrackRepository;
    }

    public Task<bool> Handle(ArchiveTrackCommand request, CancellationToken cancellationToken)
    {
        return _audioTrackRepository.UpdateStatusAsync(request.AudioTrackId, AudioTrackStatus.Archived, cancellationToken);
    }
}
