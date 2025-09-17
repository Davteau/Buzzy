namespace Api.Endpoints;
public static class OfferingEndpointResponses
{
    public record ErrorDto(string Code, string Description);

    public record InternalServerErrorDto(string Error, string Type, int StatusCode);

    public static RouteHandlerBuilder WithGetResponse<T>(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces<T>(StatusCodes.Status200OK)
            .Produces<ErrorDto>(StatusCodes.Status404NotFound)
            .Produces<ErrorDto>(StatusCodes.Status400BadRequest)
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError);
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
            .Produces<ErrorDto>(StatusCodes.Status400BadRequest)
            .Produces<ErrorDto>(StatusCodes.Status404NotFound)
            .Produces<ErrorDto>(StatusCodes.Status401Unauthorized) 
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError);
    }

    public static RouteHandlerBuilder WithNoContentResponse(this RouteHandlerBuilder builder)
    {
        return builder
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ErrorDto>(StatusCodes.Status404NotFound)
            .Produces<ErrorDto>(StatusCodes.Status401Unauthorized)
            .Produces<InternalServerErrorDto>(StatusCodes.Status500InternalServerError);
    }
}