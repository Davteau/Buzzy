using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvitationLinks;

public class InvitationLinkDto
{
    public Guid Id { get; set; }
    public string? CompanyName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
}

