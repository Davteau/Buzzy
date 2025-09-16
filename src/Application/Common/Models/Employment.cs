using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models;

public class Employment
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid CompanyId { get; set; }
    public Company? Company { get; set; }

    public IEnumerable<Appointment>? Appointments { get; set; }
    public IEnumerable<EmploymentOffering>? EmploymentOfferings { get; set; }
}
