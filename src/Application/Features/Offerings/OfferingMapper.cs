using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offerings;

public static class OfferingMapper
{
    public static OfferingDto ToDto(this Offering offering)
    {
        return new OfferingDto
        {
            Id = offering.Id,
            Name = offering.Name,
            Description = offering.Description,
            Price = offering.Price,
            Duration = offering.Duration,
            IsActive = offering.IsActive,

            CategoryId = offering.CategoryId,
            CategoryName = offering.Category?.Name,

            CompanyId = offering.CompanyId,
            CompanyName = offering.Company?.Name
        };
    }
}
