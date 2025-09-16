using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class EmploymentOffering
{
    public Guid Id { get; set; }

    public Guid EmploymentId { get; set; }
    public Employment? Employment { get; set; }

    public Guid OfferingId { get; set; }
    public Offering? Offering { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be above 0.")]
    public decimal Price { get; set; }

    public TimeSpan Duration { get; set; }
}
