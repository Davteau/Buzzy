using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.InvitationLinks.Handlers;

public record GetInvitationLinkCommand(Guid Id) : IRequest<ErrorOr<InvitationLinkDto>>;

internal sealed class GetInvitationLinkHandler(ApplicationDbContext context) : IRequestHandler<GetInvitationLinkCommand, ErrorOr<InvitationLinkDto>>
{
    public async Task<ErrorOr<InvitationLinkDto>> Handle(GetInvitationLinkCommand request, CancellationToken cancellationToken)
    {
        var invitationLink = await context.InvitationLinks
            .Include(c => c.Company)
            .Include(u => u.User)
            .FirstOrDefaultAsync(i => i.Id == request.Id,cancellationToken);
        
        if (invitationLink is null)
        {
            return Error.NotFound("InvitationLink.NotFound", $"Invitation link with token {request.Id} not found.");
        }

        if (invitationLink.ExpirationDate < DateTime.UtcNow)
        {
            return Error.Conflict("Invitation.Expired", "This invitation link is expired");
        }

        var employmentExists = await context.Employments
            .AnyAsync(e => e.UserId == invitationLink.UserId && e.CompanyId == invitationLink.CompanyId, cancellationToken);

        if (employmentExists)
        {
            return Error.Conflict("Employment.AlreadyExists", "User is already part of the company");
        }

        return invitationLink.ToDto();
    }
}

