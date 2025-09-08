using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;

namespace Application.Features.Offerings.Commands.CreateOffering;

public record CreateOfferingCommand(string Name, string Description, decimal Price, int Duration) : IRequest<ErrorOr<Offering>>;

internal sealed class CreateOfferingHandler(ApplicationDbContext context) : IRequestHandler<CreateOfferingCommand, ErrorOr<Offering>>
{
    public async Task<ErrorOr<Offering>> Handle(CreateOfferingCommand request, CancellationToken cancellationToken)
    {
        var offering = new Offering
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Duration = TimeSpan.FromMinutes(request.Duration),
        };

        context.Offerings.Add(offering);

        await context.SaveChangesAsync(cancellationToken);

        return offering;
    }
}
