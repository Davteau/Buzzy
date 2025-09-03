using Application.Common.Models;
using Application.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services;

public record class GetServiceQuery(Guid Id) : IRequest<Service>;

internal sealed class GetServiceHandler(ApplicationDbContext context) : IRequestHandler<GetServiceQuery, Service>
{
    public async Task<Service> Handle(GetServiceQuery request, CancellationToken cancellationToken)
    {
        var service = await context.Services.FindAsync(request.Id);
        if (service is null)
        {
            throw new KeyNotFoundException($"Service with ID {request.Id} not found.");
        }

        return service;
    }
}
