using Application.Common.Models;
using Application.Infrastructure.Persistence;
using MediatR;

namespace Application.Features.Services;

public record class GetServiceQuery(Guid Id) : IRequest<Offering>;

internal sealed class GetServiceHandler(ApplicationDbContext context) : IRequestHandler<GetServiceQuery, Offering>
{
    public async Task<Offering> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var service = await context.Offerings.FindAsync(request.Id);
        if (service is null)
        {
            throw new KeyNotFoundException($"Service with ID {request.Id} not found.");
        }

        return service;
    }
}
