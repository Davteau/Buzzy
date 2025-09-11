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

    public Guid ClientId { get; set; }
    public User Client { get; set; }

    public Guid BusinessId { get; set; }
    public Business Business { get; set; }

    public Guid EmployeeOfferingId { get; set; }
    public EmployeeOffering Offering { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public AppointmentStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
