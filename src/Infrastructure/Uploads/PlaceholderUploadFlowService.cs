using HassanAdly.Application.Admin.Tracks.Dtos;
using HassanAdly.Application.Common.Interfaces;

namespace HassanAdly.Infrastructure.Uploads;

public sealed class PlaceholderUploadFlowService : IUploadFlowService
{
    public Task<InitUploadDto> InitTrackUploadAsync(long audioTrackId, CancellationToken cancellationToken)
    {
        var objectKey = $"audio/uploads/pending/{audioTrackId}.mp3";
        var uploadUrl = $"/api/v1/admin/tracks/{audioTrackId}/upload-placeholder";
        return Task.FromResult(new InitUploadDto(uploadUrl, objectKey));
    }

    public Task<bool> FinalizeTrackUploadAsync(long audioTrackId, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}
