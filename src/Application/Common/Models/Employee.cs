using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class Employee
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } // The user account associated with the employee

    public Guid BusinessId { get; set; }
    public Business Business { get; set; } // The business the employee works for

    public IEnumerable<Appointment>? Appointments { get; set; } // List of appointments assigned to the employee
    public IEnumerable<Offering>? Offerings { get; set; } // List of services the employee can perform
}
