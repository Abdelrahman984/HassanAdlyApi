using FluentValidation;

namespace HassanAdly.Application.Admin.Auth.Commands.AdminLogin;

public sealed class AdminLoginCommandValidator : AbstractValidator<AdminLoginCommand>
{
    public AdminLoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(200);
        RuleFor(x => x.Password).NotEmpty().MaximumLength(200);
    }
}
