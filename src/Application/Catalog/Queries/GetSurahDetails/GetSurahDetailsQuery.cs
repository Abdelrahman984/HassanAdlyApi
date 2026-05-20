using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Enums;
using MediatR;

namespace HassanAdly.Application.Catalog.Queries.GetSurahDetails;

public sealed record GetSurahDetailsQuery(short SurahId) : IRequest<SurahDetailsDto?>;

public sealed class GetSurahDetailsQueryHandler : IRequestHandler<GetSurahDetailsQuery, SurahDetailsDto?>
{
    private readonly ISurahRepository _surahRepository;

    public GetSurahDetailsQueryHandler(ISurahRepository surahRepository)
    {
        _surahRepository = surahRepository;
    }

    public async Task<SurahDetailsDto?> Handle(GetSurahDetailsQuery request, CancellationToken cancellationToken)
    {
        var surah = await _surahRepository.GetByIdAsync(request.SurahId, cancellationToken);
        if (surah is null)
        {
            return null;
        }

        var availableQiraat = surah.AudioTracks
            .Where(t => t.Status is AudioTrackStatus.Published or AudioTrackStatus.Ready)
            .GroupBy(t => t.QiraaId)
            .Select(g =>
            {
                var track = g.OrderByDescending(t => t.Version).First();
                var qiraa = track.Qiraa;
                return new AvailableQiraaDto(
                    track.QiraaId,
                    qiraa?.NameArabic ?? string.Empty,
                    qiraa?.RawiArabic ?? string.Empty,
                    track.Id,
                    track.DurationSeconds,
                    true);
            })
            .OrderBy(x => x.Id)
            .ToList();

        return new SurahDetailsDto(
            surah.Id,
            surah.NameArabic,
            surah.NameTransliteration,
            surah.RevelationType,
            surah.VerseCount,
            availableQiraat);
    }
}
