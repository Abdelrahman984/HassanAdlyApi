using FluentValidation;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Enums;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Commands.UpdateAdminTrack;

public sealed record UpdateAdminTrackCommand(
    long AudioTrackId,
    string TitleArabic,
    int DurationSeconds,
    long FileSizeBytes,
    int BitrateKbps,
    string AudioObjectKey,
    string? Format,
    string? Checksum,
    int Version,
    AudioTrackStatus Status) : IRequest<bool>;

public sealed class UpdateAdminTrackCommandValidator : AbstractValidator<UpdateAdminTrackCommand>
{
    public UpdateAdminTrackCommandValidator()
    {
        RuleFor(x => x.AudioTrackId).GreaterThan(0);
        RuleFor(x => x.TitleArabic).NotEmpty().MaximumLength(400);
        RuleFor(x => x.AudioObjectKey).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.DurationSeconds).GreaterThanOrEqualTo(0);
        RuleFor(x => x.FileSizeBytes).GreaterThanOrEqualTo(0);
        RuleFor(x => x.BitrateKbps).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Version).GreaterThan(0);
    }
}

public sealed class UpdateAdminTrackCommandHandler : IRequestHandler<UpdateAdminTrackCommand, bool>
{
    private readonly IAudioTrackRepository _audioTrackRepository;

    public UpdateAdminTrackCommandHandler(IAudioTrackRepository audioTrackRepository)
    {
        _audioTrackRepository = audioTrackRepository;
    }

    public async Task<bool> Handle(UpdateAdminTrackCommand request, CancellationToken cancellationToken)
    {
        var track = await _audioTrackRepository.GetByIdAsync(request.AudioTrackId, cancellationToken);
        if (track is null)
        {
            return false;
        }

        track.TitleArabic = request.TitleArabic.Trim();
        track.DurationSeconds = request.DurationSeconds;
        track.FileSizeBytes = request.FileSizeBytes;
        track.BitrateKbps = request.BitrateKbps;
        track.AudioObjectKey = request.AudioObjectKey.Trim();
        track.Format = string.IsNullOrWhiteSpace(request.Format) ? null : request.Format.Trim();
        track.Checksum = string.IsNullOrWhiteSpace(request.Checksum) ? null : request.Checksum.Trim();
        track.Version = request.Version;
        track.Status = request.Status;

        await _audioTrackRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
