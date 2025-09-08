using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class Offering
{
    public Guid Id { get; set; }
    public Guid? BusinessId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public OfferingCategory Category { get; set; }

    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsActive { get; set; } = false;
}
