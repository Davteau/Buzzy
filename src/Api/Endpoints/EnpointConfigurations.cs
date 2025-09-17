namespace Api.Endpoints;
﻿
public static class OfferingEndpointResponses
{
    public record InternalServerErrorDto(string Error, string Type, int StatusCode);

    public static RouteHandlerBuilder WithGetResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces<T>(StatusCodes.Status200OK)
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
    }

    public static RouteHandlerBuilder WithGetListResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces<T>(StatusCodes.Status200OK)
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError);
    }

    public static RouteHandlerBuilder WithCreatedResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces<T>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized) 
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError);
    }

    public static RouteHandlerBuilder WithNoContentResponse(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized)
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError);
    }
}