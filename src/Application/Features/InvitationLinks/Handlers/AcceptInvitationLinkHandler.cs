using Application.Common.Models;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.InvitationLinks.Handlers;

public record AcceptInvitationLinkCommand(Guid Id) : IRequest<ErrorOr<Unit>>;

internal sealed class AcceptInvitationLinkHandler(ApplicationDbContext context): IRequestHandler<AcceptInvitationLinkCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(AcceptInvitationLinkCommand request, CancellationToken cancellationToken)
    {
        var invitation = await context.InvitationLinks
            .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken);

        if (invitation is null || invitation.ExpirationDate < DateTime.UtcNow)
        {
            return Error.NotFound("Invitation.NotFound", "Invalid or expired invitation");
        }

        var employmentExists = await context.Employments
            .AnyAsync(e => e.UserId == invitation.UserId && e.CompanyId == invitation.CompanyId, cancellationToken);

        if (employmentExists)
        {
            return Error.Conflict("Employment.AlreadyExists", "User is already part of the company");
        }

        var employment = new Employment()
        {
            UserId = invitation.UserId,
            CompanyId = invitation.CompanyId
        };

        context.Employments.Add(employment);

        await context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

