using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Companies.Handlers;

public record CreateCompanyCommand(CreateCompanyDto CompanyDto, Guid Id) : IRequest<ErrorOr<CompanyDto>>;

internal sealed class CreateCompanyHandler(ApplicationDbContext context) : IRequestHandler<CreateCompanyCommand, ErrorOr<CompanyDto>>
{
    public async Task<ErrorOr<CompanyDto>> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var owner = await context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);

        if (owner is null)
        {
            return Error.NotFound("User.NotFound", $"User not found");
        }

        var company = new Company
        {
            Owner = owner,
            Name = request.CompanyDto.Name,
            Description = request.CompanyDto.Description
        };

        context.Companies.Add(company);

        await context.SaveChangesAsync(cancellationToken);

        return company.ToDto();
    }
}