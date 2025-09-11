using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class Business
{
    public Guid Id { get; set; }

    public Guid OwnerId { get; set; }
    
    [MaxLength(80)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public IEnumerable<Employee>? Employees { get; set; }

    public IEnumerable<Offering>? Offerings { get; set; }
}
