using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;

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