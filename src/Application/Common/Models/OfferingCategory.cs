using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class OfferingCategory
{
    public Guid Id { get; set; }

    [MaxLength(50)]
    public required string Name { get; set; }
}
