using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Offeringss.Handlers;
public record class GetOfferingQuery(Guid Id) : IRequest<ErrorOr<Offering>>;
internal sealed class GetOfferingHandler(ApplicationDbContext context) : IRequestHandler<GetOfferingQuery, ErrorOr<Offering>>
{
    public async Task<ErrorOr<Offering>> Handle(GetOfferingQuery request, CancellationToken cancellationToken)
    {
        var offering = await context.Offerings
            .Include(c => c.Category)
            .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (offering is null)
        {
            return Error.NotFound("Offering.NotFound", $"Offering with Id {request.Id} not found.");
        }

        return offering;
    }
}