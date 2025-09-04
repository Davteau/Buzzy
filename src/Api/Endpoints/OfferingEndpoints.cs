using Api.Endpoints.Offerings;
using Application.Common.Models;
using Application.Features.Services;
using Application.Features.Offerings.Commands.CreateOffering;
using FizzWare.NBuilder;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Api.Endpoints
{
    public static class OfferingEndpoints
    {
        public static void MapOfferingEndpoints(this WebApplication app)
        {
            var serviceGroup = app.MapGroup("/api/services")
                .WithTags("Service");

            serviceGroup.MapPost("/", CreateOfferingEndpoint.Handle)
                .WithSummary("Create a new service")
                .WithDescription("Adds a new service to the system")
                .Produces<Offering>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);


            serviceGroup.MapDelete("/{id}", async ([FromRoute] string id, [FromServices] IMediator mediator) =>
            {
                if (!Guid.TryParse(id, out var guid))
                {
                    return Results.ValidationProblem(new Dictionary<string, string[]>
                    {
                        ["Id"] = new[] { "Invalid or missing Id." }
                    });
                }

                var command = new DeleteServiceCommand(guid);

                try
                {
                    await mediator.Send(command);
                    return Results.NoContent();
                }
                catch (FluentValidation.ValidationException ex)
                {
                    return Results.ValidationProblem(ex.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            g => g.Key,
                            g => g.Select(e => e.ErrorMessage).ToArray()
                        ));
                }
                catch (KeyNotFoundException ex)
                {
                    return Results.NotFound(new { Message = ex.Message }); // 404
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.Message, statusCode: 500); // 500
                }

            })
            .WithSummary("Delete a service")
            .WithDescription("Deletes an existing service by its ID.")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);

            serviceGroup.MapGet("/", async (IMediator mediator) =>
            {
                try
                {
                    var result = await mediator.Send(new GetServicesQuery());
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.Message, statusCode: 500);
                }
            })
            .WithSummary("Get services")
            .WithDescription("Returns the list of services")
            .Produces<IEnumerable<Offering>>(StatusCodes.Status200OK);

            serviceGroup.MapGet("/{id}", async ([FromRoute] string id ,IMediator mediator) =>
            {
                if (!Guid.TryParse(id, out var guid))
                {
                    return Results.ValidationProblem(new Dictionary<string, string[]>
                    {
                        ["Id"] = new[] { "Invalid or missing Id." }
                    });
                }

                var command = new GetServiceQuery(guid);

                try
                {
                    var result = await mediator.Send(command);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.Message, statusCode: 500);
                }
            })
            .WithSummary("Get service")
            .WithDescription("Returns a service")
            .Produces<Offering>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
