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

public record class GetServicesQuery() : IRequest<IEnumerable<Offering>>;

internal sealed class GetServicesHandler(ApplicationDbContext context) : IRequestHandler<GetServicesQuery, IEnumerable<Offering>>
{
    public async Task<IEnumerable<Offering>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        return await context.Offerings.ToListAsync(cancellationToken);
    }
}