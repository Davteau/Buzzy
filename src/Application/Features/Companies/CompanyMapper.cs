using Application.Common.Models;

namespace Application.Features.Companies;

public static class CompanyMapper
{
    public static CompanyDto ToDto(this Company entity)
    {
        return new CompanyDto
        {
            Id = entity.Id,
            OwnerEmail = entity.Owner?.Email,
            Name = entity.Name,
            Description = entity.Description
        };
    }
}