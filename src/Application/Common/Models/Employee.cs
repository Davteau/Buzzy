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
    public User User { get; set; }

    public Guid BusinessId { get; set; }
    public Business Business { get; set; }

    public IEnumerable<Appointment>? Appointments { get; set; }
    public IEnumerable<EmployeeOffering>? EmployeeOfferings { get; set; }
}
