using Application.Common.Models;
using Application.Common.Services;
using Application.Infrastructure.Persistence;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.InvitationLinks.Handlers;

public record CreateInvitationLinkCommand(string email, Guid companyId) : IRequest<ErrorOr<InvitationLink>>;

internal sealed class CreateInvitationLinkHandler(ApplicationDbContext context, EmailService emailService, InvitationService invitationService) : IRequestHandler<CreateInvitationLinkCommand, ErrorOr<InvitationLink>>
{
    public async Task<ErrorOr<InvitationLink>> Handle(CreateInvitationLinkCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == request.email, cancellationToken);

        if (user is null)
        {
            return Error.NotFound("User.NotFound", $"User not found.");
        }

        var company = await context.Companies.FirstOrDefaultAsync(c => c.Id == request.companyId, cancellationToken);

        if (company is null)
        {
            return Error.NotFound("Company.NotFound", $"Company not found.");
        }

        var oldInvitations = await context.InvitationLinks
            .Where(i => i.UserId == user.Id && i.CompanyId == company.Id && i.ExpirationDate > DateTime.MinValue)
            .ToListAsync(cancellationToken);

        foreach (var oldInvitation in oldInvitations)
        {
            oldInvitation.ExpirationDate = DateTime.MinValue;
        }

        var invitationLink = new InvitationLink
        {
            UserId = user.Id,
            CompanyId = company.Id,
            ExpirationDate = DateTime.UtcNow.AddDays(2)
        };

        context.InvitationLinks.Add(invitationLink);

        await context.SaveChangesAsync(cancellationToken);

        var inviteLink = await invitationService.GenerateInvitationLink(invitationLink.Id);

        await emailService.SendAsync(user.Email, "Invitation", $"Click to join: {inviteLink}");

        return invitationLink;
    }
}
