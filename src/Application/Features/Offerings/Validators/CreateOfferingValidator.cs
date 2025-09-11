using Application.Features.Offerings.Commands.CreateOffering;
using FluentValidation;

namespace Application.Features.Services.Validators;
internal sealed class CreateOfferingValidator : AbstractValidator<CreateOfferingCommand>
{
    public CreateOfferingValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required")
            .Must(id => id != Guid.Empty).WithMessage("Category must be a valid GUID.");

    }
}