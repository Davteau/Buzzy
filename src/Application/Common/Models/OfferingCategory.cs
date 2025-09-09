using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class OfferingCategory
{
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
}
