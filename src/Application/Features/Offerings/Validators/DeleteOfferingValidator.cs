using Application.Features.Services.Handlers;
using FluentValidation;

namespace Application.Features.Services.Validators;

internal sealed class DeleteOfferingValidator : AbstractValidator<DeleteOfferingCommand>
{
    public DeleteOfferingValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id must be provided");
    }
}
