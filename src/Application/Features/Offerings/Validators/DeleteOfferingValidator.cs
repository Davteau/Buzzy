using Application.Features.Services.Handlers;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services.Validators;

internal sealed class DeleteOfferingValidator : AbstractValidator<DeleteOfferingCommand>
{
    public DeleteOfferingValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id must be provided");
    }
}
