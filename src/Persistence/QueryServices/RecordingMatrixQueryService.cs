using HassanAdly.Application.Admin.RecordingMatrix.Queries.GetRecordingMatrix;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace HassanAdly.Persistence.QueryServices;

public sealed class RecordingMatrixQueryService : IRecordingMatrixQueryService
{
    private readonly AppDbContext _dbContext;

    public RecordingMatrixQueryService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RecordingMatrixDto> GetAsync(CancellationToken cancellationToken)
    {
        var qiraat = await _dbContext.Qiraat
            .AsNoTracking()
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new RecordingMatrixQiraaDto(x.Id, x.NameArabic))
            .ToListAsync(cancellationToken);

        var surahs = await _dbContext.Surahs
            .AsNoTracking()
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new { x.Id, x.NameArabic })
            .ToListAsync(cancellationToken);

        var latestTracks = await _dbContext.AudioTracks
            .AsNoTracking()
            .GroupBy(x => new { x.SurahId, x.QiraaId })
            .Select(g => g.OrderByDescending(x => x.Version).First())
            .Select(x => new { x.SurahId, x.QiraaId, x.Status, x.Id })
            .ToListAsync(cancellationToken);

        var trackLookup = latestTracks.ToDictionary(x => (x.SurahId, x.QiraaId), x => x);

        var surahDtos = surahs.Select(s =>
        {
            var cells = qiraat.Select(q =>
            {
                if (trackLookup.TryGetValue((s.Id, q.Id), out var track))
                {
                    return new RecordingMatrixCellDto(q.Id, track.Status, track.Id);
                }

                return new RecordingMatrixCellDto(q.Id, Domain.Enums.AudioTrackStatus.Draft, null);
            }).ToList();

            return new RecordingMatrixSurahDto(s.Id, s.NameArabic, cells);
        }).ToList();

        return new RecordingMatrixDto(surahDtos, qiraat);
    }
}
