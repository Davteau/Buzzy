using Application.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ErrorOr;

namespace Application.Features.Companies.Handlers;

public record DeleteCompanyCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

internal sealed class DeleteCompanyHandler(ApplicationDbContext context) : IRequestHandler<DeleteCompanyCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await context.Companies.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken: cancellationToken);

        if (company is null)
        {
            return Error.NotFound("Company.NotFound", "Company not found");
        }

        context.Companies.Remove(company);

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}