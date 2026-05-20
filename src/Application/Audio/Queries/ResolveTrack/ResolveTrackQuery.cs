using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Audio.Queries.ResolveTrack;

public sealed record ResolveTrackQuery(short SurahId, short QiraaId) : IRequest<ResolveTrackDto?>;

public sealed class ResolveTrackQueryHandler : IRequestHandler<ResolveTrackQuery, ResolveTrackDto?>
{
    private readonly IAudioTrackRepository _audioTrackRepository;
    private readonly IMediaUrlResolver _mediaUrlResolver;

    public ResolveTrackQueryHandler(IAudioTrackRepository audioTrackRepository, IMediaUrlResolver mediaUrlResolver)
    {
        _audioTrackRepository = audioTrackRepository;
        _mediaUrlResolver = mediaUrlResolver;
    }

    public async Task<ResolveTrackDto?> Handle(ResolveTrackQuery request, CancellationToken cancellationToken)
    {
        var track = await _audioTrackRepository.ResolveAsync(request.SurahId, request.QiraaId, cancellationToken);
        if (track is null)
        {
            return null;
        }

        var streamUrl = _mediaUrlResolver.ResolvePublicUrl(track.AudioObjectKey);

        return new ResolveTrackDto(
            track.Id,
            track.SurahId,
            track.Surah?.NameArabic ?? string.Empty,
            track.QiraaId,
            track.Qiraa?.NameArabic ?? string.Empty,
            track.DurationSeconds,
            streamUrl,
            streamUrl,
            track.BitrateKbps,
            track.FileSizeBytes);
    }
}
