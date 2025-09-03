using Application.Common.Models;
using Application.Infrastructure.Persistence;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Services;

public record class GetServicesQuery() : IRequest<IEnumerable<Service>>;

internal sealed class GetServicesHandler(ApplicationDbContext context) : IRequestHandler<GetServicesQuery, IEnumerable<Service>>
{
    public async Task<IEnumerable<Service>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        return await context.Services.ToListAsync(cancellationToken);
    }
}