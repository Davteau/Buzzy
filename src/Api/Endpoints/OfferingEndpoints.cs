using Application.Common.Models;
using Application.Features.Offerings.Commands.CreateOffering;
using Application.Features.Offeringss.Handlers;
using Application.Features.Services.Handlers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Api.Endpoints;

public static class OfferingEndpoints
{
    public static void MapOfferingEndpoints(this WebApplication app)
    {
        var serviceGroup = app.MapGroup("/api/offerings")
            .WithTags("Offering");

        serviceGroup.MapPost("/", async (CreateOfferingCommand command, [FromServices] IMediator mediator) =>
        {
            ErrorOr<Offering> result = await mediator.Send(command);
            return result.MatchToResultCreated($"/api/offerings/{result.Value?.Id}");
        })
        .WithSummary("Create a new offering")
        .WithDescription("Adds a new offering to the system")
        .WithCreatedResponse<Offering>()
        .WithOpenApi(o =>
        {
            o.Summary = "Create a new offering";
            o.Description = "Adds a new offering to the system";
            return o;
        });

        serviceGroup.MapDelete("/{id}", async ([FromRoute] Guid id, [FromServices] IMediator mediator) =>
        {
            ErrorOr<Unit> result = await mediator.Send(new DeleteOfferingCommand(id));
            return result.MatchToResultNoContent();

        })
        .WithSummary("Delete an offering")
        .WithDescription("Deletes an existing offering by its ID.")
        .WithNoContentResponse();

        serviceGroup.MapGet("/", async (IMediator mediator) =>
        {
            ErrorOr<IEnumerable<Offering>> result = await mediator.Send(new GetOfferingsQuery());
            return result.MatchToResult();
        })
        .WithSummary("Get offerings")
        .WithDescription("Returns the list of offerings")
        .Produces<IEnumerable<Offering>>(StatusCodes.Status200OK);

        serviceGroup.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator) =>
        {
            ErrorOr<Offering> result = await mediator.Send(new GetOfferingQuery(id));
            return result.MatchToResult();

        })
        .WithSummary("Get offering")
        .WithDescription("Returns an offering")
        .Produces<Offering>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}

