using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class Offering
{
    public Guid Id { get; set; }
    public Guid? CompanyId { get; set; }
    public Company? Company { get; set; }

    [MaxLength(80)]
    public required string Name { get; set; }

    [MaxLength(250)]
    public required string Description { get; set; }

    public Guid CategoryId { get; set; }
    public OfferingCategory? Category { get; set; }

    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsActive { get; set; } = false;
}
