using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Offerings.Handlers;

public record CreateOfferingCommand(CreateOfferingDto OfferingDto) : IRequest<ErrorOr<OfferingDto>>;

internal sealed class CreateOfferingHandler(ApplicationDbContext context) : IRequestHandler<CreateOfferingCommand, ErrorOr<OfferingDto>>
{
    public async Task<ErrorOr<OfferingDto>> Handle(CreateOfferingCommand request, CancellationToken cancellationToken)
    {
        var company = await context.Companies
            .FirstOrDefaultAsync(c => c.Id == request.OfferingDto.CompanyId, cancellationToken);

        if (company is null)
        {
            return Error.NotFound("Company.NotFound", $"Company not found.");
        }

        var category = await context.OfferingCategories
            .FirstOrDefaultAsync(c => c.Id == request.OfferingDto.CategoryId, cancellationToken);

        if (category is null)
        {
            return Error.NotFound("Category.NotFound", $"Category not found.");
        }

        var offering = new Offering
        {
            Company = company,
            Name = request.OfferingDto.Name,
            Description = request.OfferingDto.Description,
            Price = request.OfferingDto.Price,
            Duration = TimeSpan.FromMinutes(request.OfferingDto.Duration),
            Category = category
        };

        context.Offerings.Add(offering);
        Console.WriteLine(offering.Id);

        await context.SaveChangesAsync(cancellationToken);

        return offering.ToDto();
    }
}
