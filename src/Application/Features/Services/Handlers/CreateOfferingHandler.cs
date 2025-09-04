using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Offerings.Commands.CreateOffering;

public record CreateOfferingCommand(string Name, string Description, decimal Price)
    : IRequest<ErrorOr<Offering>>;

internal sealed class CreateOfferingHandler(
    ApplicationDbContext context
) : IRequestHandler<CreateOfferingCommand, ErrorOr<Offering>>
{
    public async Task<ErrorOr<Offering>> Handle(CreateOfferingCommand request, CancellationToken cancellationToken)
    {
        var offering = new Offering
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price
        };

        context.Services.Add(offering);
        await context.SaveChangesAsync(cancellationToken);

        return offering;
    }
}
