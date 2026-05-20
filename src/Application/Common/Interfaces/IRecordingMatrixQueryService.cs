using HassanAdly.Application.Admin.RecordingMatrix.Queries.GetRecordingMatrix;

namespace HassanAdly.Application.Common.Interfaces;

public interface IRecordingMatrixQueryService
{
    Task<RecordingMatrixDto> GetAsync(CancellationToken cancellationToken);
}
