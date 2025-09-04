using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offeringss.Handlers;
public record class GetOfferingQuery(Guid Id) : IRequest<ErrorOr<Offering>>;
internal sealed class GetOfferingHandler(ApplicationDbContext context) : IRequestHandler<GetOfferingQuery, ErrorOr<Offering>>
{
    public async Task<ErrorOr<Offering>> Handle(GetOfferingQuery request, CancellationToken cancellationToken)
    {
        var offering = await context.Offerings.FindAsync(request.Id);

        if (offering is null)
        {
            return Error.NotFound("Offering.NotFound", $"Offering with Id {request.Id} not found.");
        }

        return offering;
    }
}