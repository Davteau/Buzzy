using System.ComponentModel.DataAnnotations;

namespace Application.Common.Models;

public class Company
{
    public Guid Id { get; set; }

    public User? Owner { get; set; }

    public Guid OwnerId { get; set; }
    
    [MaxLength(80)]
    public required string Name { get; set; }

    [MaxLength(250)] 
    public string? Description { get; set; }

    public IEnumerable<Employment>? Employments { get; set; }

    public IEnumerable<Offering>? Offerings { get; set; }
}
