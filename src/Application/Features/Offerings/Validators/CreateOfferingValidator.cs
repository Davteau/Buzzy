using Application.Features.Offerings.Handlers;
using FluentValidation;

namespace Application.Features.Services.Validators;
internal sealed class CreateOfferingValidator : AbstractValidator<CreateOfferingCommand>
{
    public CreateOfferingValidator()
    {
        RuleFor(x => x.OfferingDto.CompanyId)
            .NotEmpty().WithMessage("Category is required")
            .Must(id => id != Guid.Empty).WithMessage("Category must be a valid GUID.");

        RuleFor(x => x.OfferingDto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.OfferingDto.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

        RuleFor(x => x.OfferingDto.Price)
            .NotEmpty().WithMessage("Price is required")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value.");

        RuleFor(x => x.OfferingDto.CategoryId)
            .NotEmpty().WithMessage("Category is required")
            .Must(id => id != Guid.Empty).WithMessage("Category must be a valid GUID.");

    }
}