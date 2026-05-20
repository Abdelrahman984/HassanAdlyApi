using FluentValidation;
using HassanAdly.Application.Common.Interfaces;
using HassanAdly.Domain.Entities;
using HassanAdly.Domain.Enums;
using MediatR;

namespace HassanAdly.Application.Admin.Tracks.Commands.CreateAdminTrack;

public sealed record CreateAdminTrackCommand(
    long SheikhId,
    short SurahId,
    short QiraaId,
    string TitleArabic,
    int DurationSeconds,
    long FileSizeBytes,
    int BitrateKbps,
    string AudioObjectKey,
    string? Format,
    string? Checksum,
    int Version,
    AudioTrackStatus Status) : IRequest<long>;

public sealed class CreateAdminTrackCommandValidator : AbstractValidator<CreateAdminTrackCommand>
{
    public CreateAdminTrackCommandValidator()
    {
        RuleFor(x => x.SheikhId).GreaterThan(0);
        RuleFor(x => x.SurahId).GreaterThan((short)0);
        RuleFor(x => x.QiraaId).GreaterThan((short)0);
        RuleFor(x => x.TitleArabic).NotEmpty().MaximumLength(400);
        RuleFor(x => x.AudioObjectKey).NotEmpty().MaximumLength(2000);
        RuleFor(x => x.DurationSeconds).GreaterThanOrEqualTo(0);
        RuleFor(x => x.FileSizeBytes).GreaterThanOrEqualTo(0);
        RuleFor(x => x.BitrateKbps).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Version).GreaterThan(0);
    }
}

public sealed class CreateAdminTrackCommandHandler : IRequestHandler<CreateAdminTrackCommand, long>
{
    private readonly IAudioTrackRepository _audioTrackRepository;

    public CreateAdminTrackCommandHandler(IAudioTrackRepository audioTrackRepository)
    {
        _audioTrackRepository = audioTrackRepository;
    }

    public async Task<long> Handle(CreateAdminTrackCommand request, CancellationToken cancellationToken)
    {
        var existing = await _audioTrackRepository.GetBySheikhSurahAndQiraaAsync(
            request.SheikhId,
            request.SurahId,
            request.QiraaId,
            cancellationToken);

        if (existing is not null)
        {
            throw new InvalidOperationException("A track already exists for the selected Sheikh, Surah, and Qira'a.");
        }

        var track = new AudioTrack
        {
            Id = 0,
            SheikhId = request.SheikhId,
            SurahId = request.SurahId,
            QiraaId = request.QiraaId,
            TitleArabic = request.TitleArabic.Trim(),
            DurationSeconds = request.DurationSeconds,
            FileSizeBytes = request.FileSizeBytes,
            BitrateKbps = request.BitrateKbps,
            AudioObjectKey = request.AudioObjectKey.Trim(),
            Format = string.IsNullOrWhiteSpace(request.Format) ? null : request.Format.Trim(),
            Checksum = string.IsNullOrWhiteSpace(request.Checksum) ? null : request.Checksum.Trim(),
            Version = request.Version,
            Status = request.Status
        };

        await _audioTrackRepository.AddAsync(track, cancellationToken);
        await _audioTrackRepository.SaveChangesAsync(cancellationToken);

        return track.Id;
    }
}
