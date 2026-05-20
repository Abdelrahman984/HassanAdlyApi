using HassanAdly.Application.Admin.Tracks.Dtos;

namespace HassanAdly.Application.Common.Interfaces;

public interface IUploadFlowService
{
    Task<InitUploadDto> InitTrackUploadAsync(long audioTrackId, CancellationToken cancellationToken);
    Task<bool> FinalizeTrackUploadAsync(long audioTrackId, CancellationToken cancellationToken);
}
