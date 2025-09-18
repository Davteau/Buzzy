using Application.Common.Models;

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
