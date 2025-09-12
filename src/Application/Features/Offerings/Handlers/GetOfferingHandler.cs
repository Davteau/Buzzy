using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Offerings.Handlers;

public record GetOfferingQuery(Guid Id) : IRequest<ErrorOr<Offering>>;

internal sealed class GetOfferingHandler(ApplicationDbContext context, ILogger logger) : IRequestHandler<GetOfferingQuery, ErrorOr<Offering>>
{
    public async Task<ErrorOr<Offering>> Handle(GetOfferingQuery request, CancellationToken cancellationToken)
    {
        try
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
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e, "Unexpected error occurred.");

            return Error.Unexpected();
        }        
    }
}