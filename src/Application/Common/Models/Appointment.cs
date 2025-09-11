using Application.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class Appointment
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; } // User who booked the appointment
    public User Client { get; set; }

    public Guid BusinessId { get; set; } // Business where the appointment is booked
    public Business Business { get; set; }

    public Guid EmployeeOfferingId { get; set; } // Appointment assigned to an employee
    public EmployeeOffering Offering { get; set; }

    public DateTime StartTime { get; set; } // When the appointment starts
    public DateTime EndTime { get; set; } // When the appointment ends

    public AppointmentStatus Status { get; set; } // Status of the appointment (e.g., Scheduled, Completed, Canceled)

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
