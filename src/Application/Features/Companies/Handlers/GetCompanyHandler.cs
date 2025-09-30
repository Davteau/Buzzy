using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Companies.Handlers;

public record GetCompanyQuery(Guid CompanyId) : IRequest<ErrorOr<CompanyDto>>;

internal sealed class GetCompanyHandler(ApplicationDbContext context): IRequestHandler<GetCompanyQuery, ErrorOr<CompanyDto>>
{
    public async Task<ErrorOr<CompanyDto>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await context.Companies
            .Include(c => c.Owner)
            .FirstOrDefaultAsync(c => c.Id == request.CompanyId, cancellationToken: cancellationToken);

        if (company is null)
        {
            return Error.NotFound("Company.NotFound", "Company not found");
        }

        return company.ToDto();
    }
}