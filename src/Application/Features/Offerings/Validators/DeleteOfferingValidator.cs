using Application.Features.Offerings.Handlers;
using FluentValidation;

namespace Application.Features.Offerings.Validators;

internal sealed class DeleteOfferingValidator : AbstractValidator<DeleteOfferingCommand>
{
    public DeleteOfferingValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id must be provided");
    }
}
