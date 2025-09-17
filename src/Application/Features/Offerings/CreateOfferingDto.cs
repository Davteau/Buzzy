using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Offerings;

public class CreateOfferingDto
{
    public required Guid CompanyId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be above 0.")]
    public required decimal Price { get; set; }
    public required int Duration { get; set; }
    public required Guid CategoryId { get; set; }
}