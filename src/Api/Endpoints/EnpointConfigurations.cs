using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;
public static class OfferingEndpointResponses
{
    public static RouteHandlerBuilder WithDefaultResponses(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    public static RouteHandlerBuilder WithCreatedResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces<T>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);
    }

    public static RouteHandlerBuilder WithNoContentResponse(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status500InternalServerError);
    }
}