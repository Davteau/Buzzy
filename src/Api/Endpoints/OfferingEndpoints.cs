using Application.Common;
using Application.Features.Offerings;
using Application.Features.Offerings.Handlers;
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

        serviceGroup.MapPost("/", async (CreateOfferingCommand command, [FromServices] IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<OfferingDto> result = await mediator.Send(command);
            return result.MatchToResultCreated(httpContext, $"/api/offerings/{result.Value?.Id}");
        })
        .WithSummary("Create a new offering")
        .WithDescription("Adds a new offering to the system")
        .WithCreatedResponse<OfferingDto>();

        serviceGroup.MapDelete("/{id}", async ([FromRoute] Guid id, [FromServices] IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<Unit> result = await mediator.Send(new DeleteOfferingCommand(id));
            return result.MatchToResultNoContent(httpContext);

        })
        .WithSummary("Delete an offering")
        .WithDescription("Deletes an existing offering by its ID.")
        .WithNoContentResponse();

        serviceGroup.MapGet("/", async (IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<IEnumerable<OfferingDto>> result = await mediator.Send(new GetOfferingsQuery());
            return result.MatchToResult(httpContext);
        })
        .WithSummary("Get offerings")
        .WithDescription("Returns the list of offerings")
        .WithGetListResponse<IEnumerable<OfferingDto>>();

        serviceGroup.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<OfferingDto> result = await mediator.Send(new GetOfferingQuery(id));
            return result.MatchToResult(httpContext);

        })
        .WithSummary("Get offering")
        .WithDescription("Returns an offering")
        .WithGetResponse<OfferingDto>();
    }
}

