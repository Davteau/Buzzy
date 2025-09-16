using System.Net;
using System.Text.Json;

namespace Api.Middleware;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An unhandled exception occurred.");
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var error = exception switch
        {
            KeyNotFoundException => new
            {
                HttpCode = HttpStatusCode.NotFound,
                Message = exception.Message
            },
            UnauthorizedAccessException => new
            {
                HttpCode = HttpStatusCode.Unauthorized,
                Message = "Unauthorized access."
            },
            _ => new
            {
                HttpCode = HttpStatusCode.InternalServerError,
                Message = "Unexpected error occurred on the server."
            }
        };

        var result = JsonSerializer.Serialize(new
        {
            error = error.Message,
            type = exception.GetType().Name,
            statusCode = error.HttpCode
        });

        context.Response.StatusCode = (int)error.HttpCode;

        return context.Response.WriteAsync(result);
    }
}