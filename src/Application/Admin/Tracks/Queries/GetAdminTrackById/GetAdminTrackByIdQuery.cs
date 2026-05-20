using HassanAdly.Application.Admin.Tracks.Dtos;
using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Queries.GetAdminTrackById;

public sealed record GetAdminTrackByIdQuery(long AudioTrackId) : IRequest<AdminTrackDetailsDto?>;

public sealed class GetAdminTrackByIdQueryHandler : IRequestHandler<GetAdminTrackByIdQuery, AdminTrackDetailsDto?>
{
    private readonly IAudioTrackRepository _audioTrackRepository;

    public GetAdminTrackByIdQueryHandler(IAudioTrackRepository audioTrackRepository)
    {
        _audioTrackRepository = audioTrackRepository;
    }

    public async Task<AdminTrackDetailsDto?> Handle(GetAdminTrackByIdQuery request, CancellationToken cancellationToken)
    {
        var track = await _audioTrackRepository.GetByIdAsync(request.AudioTrackId, cancellationToken);
        if (track is null)
        {
            return null;
        }

        return new AdminTrackDetailsDto(
            track.Id,
            track.SheikhId,
            track.SurahId,
            track.QiraaId,
            track.TitleArabic,
            track.Status,
            track.DurationSeconds,
            track.BitrateKbps,
            track.FileSizeBytes,
            track.AudioObjectKey,
            track.Version);
    }
}
