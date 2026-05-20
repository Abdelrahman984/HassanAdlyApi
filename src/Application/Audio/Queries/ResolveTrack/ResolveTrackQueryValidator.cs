using FluentValidation;

namespace HassanAdly.Application.Audio.Queries.ResolveTrack;

public sealed class ResolveTrackQueryValidator : AbstractValidator<ResolveTrackQuery>
{
    public ResolveTrackQueryValidator()
    {
        RuleFor(x => x.SurahId).GreaterThan((short)0);
        RuleFor(x => x.QiraaId).GreaterThan((short)0);
    }
}
