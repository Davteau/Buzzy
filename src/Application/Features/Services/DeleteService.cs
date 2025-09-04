using Application.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services;

public record class DeleteServiceCommand(Guid Id) : IRequest<Unit>;

internal sealed class DeleteServiceValidator : AbstractValidator<DeleteServiceCommand>
{
    public DeleteServiceValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id must be provided");

    }
}

internal sealed class DeleteServiceHandler(ApplicationDbContext context, IValidator<DeleteServiceCommand> validator) : IRequestHandler<DeleteServiceCommand, Unit>
{
    public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        var service = await context.Services.FindAsync(request.Id);
        if (service is null)
        {
            Results.NotFound(request.Id);
            throw new KeyNotFoundException($"Service with ID {request.Id} not found.");
        }

        context.Services.Remove(service);
        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}