using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class EmployeeOffering
{
    public Guid Id { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } // Reference to the employee

    public Guid OfferingId { get; set; }
    public Offering Offering { get; set; } // Reference to the general offering


    [Range(0.01, double.MaxValue, ErrorMessage = "Cena musi być większa od zera.")]
    public decimal Price { get; set; } // Price specific to the employee for this offering

    public TimeSpan Duration { get; set; } // Duration specific to the employee for this offering
}
