using Application.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Offerings;

public class OfferingDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }

    public bool IsActive { get; set; }


    public Guid CategoryId { get; set; }
    public string? CategoryName { get; set; }


    public Guid? CompanyId { get; set; }
    public string? CompanyName { get; set; }
}


