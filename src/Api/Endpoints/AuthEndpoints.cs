using Application.Features.Authentication;
using Application.Features.Authentication.GoogleLogin;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var serviceGroup = app.MapGroup("/api/auth")
            .WithTags("Authentication");

        serviceGroup.MapPost("google-login", async ([FromBody]  GoogleLoginCommand command , IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result;
        });
    }
}