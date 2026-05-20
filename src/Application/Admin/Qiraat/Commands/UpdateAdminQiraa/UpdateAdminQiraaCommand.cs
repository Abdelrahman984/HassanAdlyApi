using FluentValidation;
using HassanAdly.Application.Common.Interfaces;
using MediatR;

namespace HassanAdly.Application.Admin.Qiraat.Commands.UpdateAdminQiraa;

public sealed record UpdateAdminQiraaCommand(
    short QiraaId,
    string Slug,
    string NameArabic,
    string? NameEnglish,
    string RawiArabic,
    string? ImamArabic,
    string? DescriptionArabic,
    short DisplayOrder,
    bool IsPublished) : IRequest<bool>;

public sealed class UpdateAdminQiraaCommandValidator : AbstractValidator<UpdateAdminQiraaCommand>
{
    public UpdateAdminQiraaCommandValidator()
    {
        RuleFor(x => x.QiraaId).GreaterThan((short)0);
        RuleFor(x => x.Slug).NotEmpty().MaximumLength(200);
        RuleFor(x => x.NameArabic).NotEmpty().MaximumLength(400);
        RuleFor(x => x.RawiArabic).NotEmpty().MaximumLength(400);
        RuleFor(x => x.DisplayOrder).GreaterThan((short)0);
    }
}

public sealed class UpdateAdminQiraaCommandHandler : IRequestHandler<UpdateAdminQiraaCommand, bool>
{
    private readonly IQiraaRepository _qiraaRepository;

    public UpdateAdminQiraaCommandHandler(IQiraaRepository qiraaRepository)
    {
        _qiraaRepository = qiraaRepository;
    }

    public async Task<bool> Handle(UpdateAdminQiraaCommand request, CancellationToken cancellationToken)
    {
        var qiraa = await _qiraaRepository.GetByIdAsync(request.QiraaId, cancellationToken);
        if (qiraa is null)
        {
            return false;
        }

        qiraa.Slug = request.Slug.Trim();
        qiraa.NameArabic = request.NameArabic.Trim();
        qiraa.NameEnglish = string.IsNullOrWhiteSpace(request.NameEnglish) ? null : request.NameEnglish.Trim();
        qiraa.RawiArabic = request.RawiArabic.Trim();
        qiraa.ImamArabic = string.IsNullOrWhiteSpace(request.ImamArabic) ? null : request.ImamArabic.Trim();
        qiraa.DescriptionArabic = string.IsNullOrWhiteSpace(request.DescriptionArabic) ? null : request.DescriptionArabic.Trim();
        qiraa.DisplayOrder = request.DisplayOrder;
        qiraa.IsPublished = request.IsPublished;

        await _qiraaRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}
