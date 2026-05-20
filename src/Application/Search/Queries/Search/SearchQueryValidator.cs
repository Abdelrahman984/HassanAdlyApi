using FluentValidation;

namespace HassanAdly.Application.Search.Queries.Search;

public sealed class SearchQueryValidator : AbstractValidator<SearchQuery>
{
    public SearchQueryValidator()
    {
        RuleFor(x => x.Q).NotEmpty().MaximumLength(200);
    }
}
