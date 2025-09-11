using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Services.Handlers;
public record GetOfferingsQuery() : IRequest<ErrorOr<IEnumerable<Offering>>>;

internal sealed class GetOfferingsHandler(ApplicationDbContext context) : IRequestHandler<GetOfferingsQuery, ErrorOr<IEnumerable<Offering>>>
{
    public async Task<ErrorOr<IEnumerable<Offering>>> Handle(GetOfferingsQuery request, CancellationToken cancellationToken)
    {
        return await context.Offerings
            .Include(c=>c.Category)
            .ToListAsync(cancellationToken);
    }
}
