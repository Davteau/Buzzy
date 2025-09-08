using Application.Common.Models;
using ErrorOr;
using MediatR;

namespace Api.Endpoints;

public static class BusinessEndpoints
{
    public static void MapBusinessEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/business")
            .WithTags("Business");


        group.MapPost("/", async (CreateBusinessCommand command, IMediator mediator) =>
        {
            ErrorOr<Business> result = await mediator.Send(command);
            return result.Match(
                business => Results.Created($"/business/{business.Id}", business),
                errors => Results.Problem(errors));
        })
        .WithName("CreateBusiness")
        .WithSummary("Create a new business")
        .WithDescription("Creates a new business with the provided details.")
        .WithCreatedResponse<Business>();

        group.MapDelete("/{businessId:guid}", async (Guid businessId, IMediator mediator) =>
        {
            var command = new DeleteBusinessCommand(businessId);
            ErrorOr<bool> result = await mediator.Send(command);
            return result.Match(
                success => success ? Results.NoContent() : Results.NotFound(),
                errors => Results.Problem(errors));
        })
        .WithName("DeleteBusiness")
        .WithSummary("Delete a business")
        .WithDescription("Deletes a business by its unique ID.")
        .WithNoContentResponse();

        group.MapGet("/{id}", async (Guid id, IMediator mediator) =>
        {
            var query = new GetBusinessByIdQuery(businessId);
            ErrorOr<Business> result = await mediator.Send(query);
            return result.Match(
                business => Results.Ok(business),
                errors => Results.Problem(errors));
        })
        .WithName("GetBusinessById")
        .WithSummary("Get business by ID")
        .WithDescription("Retrieves a business by its unique ID.")
        .WithDefaultResponses();
        
        group.MapPut("/{businessId:guid}", async (Guid businessId, UpdateBusinessCommand command, IMediator mediator) =>
        {
            if (businessId != command.Id)
            {
                return Results.BadRequest(new { Message = "Business ID in URL does not match ID in body." });
            }
            ErrorOr<Business> result = await mediator.Send(command);
            return result.Match(
                business => Results.Ok(business),
                errors => Results.Problem(errors));
        })
        .WithName("UpdateBusiness")
        .WithSummary("Update an existing business")
        .WithDescription("Updates the details of an existing business.")
        .WithDefaultResponses();
        
    }
}
