using System.ComponentModel.DataAnnotations;

namespace Application.Features.Companies;

public class CompanyDto
{
    public Guid Id { get; set; }

    public string? OwnerEmail { get; set; }

    [MaxLength(80)]
    public required string Name { get; set; }

    [MaxLength(250)]
    public required string? Description { get; set; }
}