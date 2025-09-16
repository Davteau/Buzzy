using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InvitationLinks;

public static class InvitationLinkMapper
{
    public static InvitationLinkDto ToDto(this InvitationLink entity)
    {
        return new InvitationLinkDto
        {
            Id = entity.Id,
            Email = entity.User?.Email,
            CompanyName = entity.Company?.Name,
            ExpirationDate = entity.ExpirationDate
        };
    }
}
