using Application.Abstractions;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Features.Offerings.Handlers;

public sealed record GetOfferingQuery(Guid Id) : ICachedQuery<ErrorOr<OfferingDto>>
{
    public string CacheKey => $"offering-by-id-{Id}";
    public TimeSpan? Expiration => null;
}

internal sealed class GetOfferingHandler(ApplicationDbContext context, ILogger<GetOfferingHandler> logger) : IRequestHandler<GetOfferingQuery, ErrorOr<OfferingDto>>
{
    public async Task<ErrorOr<OfferingDto>> Handle(GetOfferingQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var offering = await context.Offerings
                .Include(c => c.Category)
                .Include(c => c.Company)
                .FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

            if (offering is null)
            {
                return Error.NotFound("Offering.NotFound", $"Offering not found.");
            }

            return offering.ToDto();
        }
        catch (Exception e)
        {
            logger.Log(LogLevel.Error, e, "Unexpected error occurred.");

            return Error.Unexpected();
        }        
    }
}