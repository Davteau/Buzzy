using Application.Common.Models;
using Application.Features.Offerings;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Services.Handlers;

public record GetOfferingsQuery() : IRequest<ErrorOr<IEnumerable<OfferingDto>>>;

internal sealed class GetOfferingsHandler(ApplicationDbContext context) : IRequestHandler<GetOfferingsQuery, ErrorOr<IEnumerable<OfferingDto>>>
{
    public async Task<ErrorOr<IEnumerable<OfferingDto>>> Handle(GetOfferingsQuery request, CancellationToken cancellationToken)
    {
        var offertingDtos = await context.Offerings
            .Select(o => new OfferingDto
            {
                Id = o.Id,
                Name = o.Name,
                Description = o.Description,
                Price = o.Price,
                Duration = o.Duration,
                IsActive = o.IsActive,
                CategoryId = o.CategoryId,
                CategoryName = o.Category != null ? o.Category.Name : null,
                CompanyId = o.CompanyId,
                CompanyName = o.Company != null ? o.Company.Name : null
            })
            .ToListAsync(cancellationToken);

        return offertingDtos;

    }
}
