using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Offerings.Commands.CreateOffering;

public record CreateOfferingCommand(string Name, string Description, decimal Price, int Duration, Guid Category) : IRequest<ErrorOr<Offering>>;

internal sealed class CreateOfferingHandler(ApplicationDbContext context) : IRequestHandler<CreateOfferingCommand, ErrorOr<Offering>>
{
    public async Task<ErrorOr<Offering>> Handle(CreateOfferingCommand request, CancellationToken cancellationToken)
    {
        var categoryExists = await context.OfferingCategories
            .AnyAsync(c => c.Id == request.Category, cancellationToken);

        if (!categoryExists)
        {
            return Error.NotFound("Category.NotFound", $"Category with Id {request.Category} not found.");
        }

        var offering = new Offering
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Duration = TimeSpan.FromMinutes(request.Duration),
            CategoryId = request.Category
        };

        context.Offerings.Add(offering);

        await context.SaveChangesAsync(cancellationToken);

        return offering;
    }
}
