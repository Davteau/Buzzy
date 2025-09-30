using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Companies.Handlers;

public record GetCompaniesQuery() : IRequest<ErrorOr<IEnumerable<CompanyDto>>>;

internal sealed class GetCompaniesHandler(ApplicationDbContext context) : IRequestHandler<GetCompaniesQuery, ErrorOr<IEnumerable<CompanyDto>>>
{
    public async Task<ErrorOr<IEnumerable<CompanyDto>>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
    {
        var companyDto = await context.Companies
            .Include(c => c.Owner)
            .Select(c => c.ToDto())
            .ToListAsync(cancellationToken);

        return companyDto;

    }
}