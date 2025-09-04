using Application.Common.Models;
using Application.Infrastructure.Persistence;
using Application.Migrations;
using ErrorOr;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services.Handlers;

public record class DeleteOfferingCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

internal sealed class DeleteOfferingHandler(ApplicationDbContext context) : IRequestHandler<DeleteOfferingCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteOfferingCommand request, CancellationToken cancellationToken)
    {
        var offering = await context.Offerings.FindAsync(request.Id);

        if (offering is null)
        {
            return Error.NotFound("Offering.NotFound", $"Offering with Id {request.Id} not found.");
        }

        context.Offerings.Remove(offering);

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}