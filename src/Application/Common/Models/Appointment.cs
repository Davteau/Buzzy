using Application.Common.Models.Enums;

namespace Application.Common.Models;

public class Appointment
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }
    public User? Client { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public Guid EmploymentOfferingId { get; set; }
    public EmploymentOffering? Offering { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public AppointmentStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
