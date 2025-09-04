using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services.Handlers;
public record GetOfferingsQuery() : IRequest<ErrorOr<IEnumerable<Offering>>>;

internal sealed class GetOfferingsHandler(ApplicationDbContext context) : IRequestHandler<GetOfferingsQuery, ErrorOr<IEnumerable<Offering>>>
{
    public async Task<ErrorOr<IEnumerable<Offering>>> Handle(GetOfferingsQuery request, CancellationToken cancellationToken)
    {
        return await context.Offerings.ToListAsync(cancellationToken);
    }
}
