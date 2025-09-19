using Application.Common.Caching;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Services.Handlers;

public record DeleteOfferingCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

internal sealed class DeleteOfferingHandler(ApplicationDbContext context, ICacheService cacheService) : IRequestHandler<DeleteOfferingCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteOfferingCommand request, CancellationToken cancellationToken)
    {
        var offering = await context.Offerings.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);

        if (offering is null)
        {
            return Error.NotFound("Offering.NotFound", $"Offering with Id {request.Id} not found.");
        }

        context.Offerings.Remove(offering);

        await cacheService.RemoveAsync($"offering-by-id-{request.Id}", cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}