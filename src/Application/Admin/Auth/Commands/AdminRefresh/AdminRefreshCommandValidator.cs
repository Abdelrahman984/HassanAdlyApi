using FluentValidation;

namespace HassanAdly.Application.Admin.Auth.Commands.AdminRefresh;

public sealed class AdminRefreshCommandValidator : AbstractValidator<AdminRefreshCommand>
{
    public AdminRefreshCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().MaximumLength(1000);
    }
}
