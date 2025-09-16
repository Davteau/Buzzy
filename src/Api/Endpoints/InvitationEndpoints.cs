using Application.Common.Models;
using Application.Features.InvitationLinks;
using Application.Features.InvitationLinks.Handlers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;
public static class InvitationEndpoints
{
    public static void MapInvitationEndpoints(this WebApplication app)
    {
        var serviceGroup = app.MapGroup("/api/invitations")
            .WithTags("Invitation");

        serviceGroup.MapPost("/", 
            async (CreateInvitationLinkCommand command, [FromServices] IMediator mediator) =>
        {
            ErrorOr<InvitationLink> result = await mediator.Send(command);
            
            return result.MatchToResultCreated($"/api/invitations/{result.Value?.Id}");
        })
        .WithSummary("Create a new invitation link")
        .WithDescription("Company generates an invitation link that will be sent to the new employee")
        .WithCreatedResponse<InvitationLink>();

        serviceGroup.MapGet("/{id}",
            async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
        {
            ErrorOr<InvitationLinkDto> result = await mediator.Send(new GetInvitationLinkCommand(id));
            
            return result.MatchToResult();
        })
        .WithSummary("Get invitation link details")
        .WithDescription("Get details of an invitation link by its ID")
        .Produces<IEnumerable<InvitationLinkDto>>(StatusCodes.Status200OK);

        serviceGroup.MapPost("/{id}/accept",
            async (AcceptInvitationLinkCommand command, [FromServices] IMediator mediator) =>
        {
            ErrorOr<Unit> result = await mediator.Send(command);
            
            return result.MatchToResultNoContent();
        })
        .WithSummary("Accept an invitation link")
        .WithDescription("User accepts the invitation link to join the company")
        .WithNoContentResponse();
    }
}

