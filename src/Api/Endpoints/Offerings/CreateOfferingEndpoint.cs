using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Application.Common;
using Application.Features.Offerings.Commands.CreateOffering;

namespace Api.Endpoints.Offerings
{
    public class CreateOfferingEndpoint
    {
        public static async Task<IResult> Handle(
            [FromBody] CreateOfferingCommand command, 
            [FromServices] IMediator mediator)
        {
            ErrorOr<Offering> result = await mediator.Send(command);
            return result.MatchToResultCreated($"/api/offerings/{result.Value?.Id}");
        }
    }
}
