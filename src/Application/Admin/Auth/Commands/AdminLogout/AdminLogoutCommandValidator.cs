using FluentValidation;

namespace HassanAdly.Application.Admin.Auth.Commands.AdminLogout;

public sealed class AdminLogoutCommandValidator : AbstractValidator<AdminLogoutCommand>
{
    public AdminLogoutCommandValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty().MaximumLength(1000);
    }
}
