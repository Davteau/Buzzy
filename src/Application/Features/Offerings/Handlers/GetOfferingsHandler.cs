using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Offerings.Handlers;

public record GetOfferingsQuery : IRequest<ErrorOr<IEnumerable<OfferingDto>>>;

internal sealed class GetOfferingsHandler(ApplicationDbContext context) : IRequestHandler<GetOfferingsQuery, ErrorOr<IEnumerable<OfferingDto>>>
{
    public async Task<ErrorOr<IEnumerable<OfferingDto>>> Handle(GetOfferingsQuery request, CancellationToken cancellationToken)
    {
        var offeringDto = await context.Offerings
            .Include(o => o.Category)
            .Include(o => o.Company)
            .Select(o => o.ToDto())
            .ToListAsync(cancellationToken);

        return offeringDto;
    }
}
