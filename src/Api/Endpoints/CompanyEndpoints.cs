using System.Runtime.InteropServices;
using Application.Common;
using Application.Features.Companies;
using Application.Features.Companies.Handlers;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Endpoints;

public static class CompanyEndpoints
{
    public static void MapCompanyEndpoints(this WebApplication app)
    {
        var serviceGroup = app.MapGroup("/api/companies")
            .WithTags("Company");


        serviceGroup.MapPost("/", async (CreateCompanyDto companyDto, [FromServices] IMediator mediator, HttpContext httpContext) =>
        {
            var userIdClaim = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!Guid.TryParse(userIdClaim, out var userId))
                return Results.Unauthorized();

            ErrorOr<CompanyDto> result = await mediator.Send(new CreateCompanyCommand(companyDto, userId));
            return result.MatchToResultCreated(httpContext, $"/api/companies/{result.Value?.Id}");
        })
        .WithSummary("Create a new company")
        .WithDescription("Adds a new company to the system")
        .WithCreatedResponse<CompanyDto>();

        serviceGroup.MapDelete("/{id}", async ([FromRoute] Guid id, [FromServices] IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<Unit> result = await mediator.Send(new DeleteCompanyCommand(id));
            return result.MatchToResultNoContent(httpContext);

        })
        .WithSummary("Delete a company")
        .WithDescription("Deletes an existing company by its ID.")
        .WithNoContentResponse();

        serviceGroup.MapGet("/", async (IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<IEnumerable<CompanyDto>> result = await mediator.Send(new GetCompaniesQuery());
            return result.MatchToResult(httpContext);
        })
        .WithSummary("Get companies")
        .WithDescription("Returns the list of companies")
        .WithGetListResponse<IEnumerable<CompanyDto>>();

        serviceGroup.MapGet("/{id}", async ([FromRoute] Guid id, IMediator mediator, HttpContext httpContext) =>
        {
            ErrorOr<CompanyDto> result = await mediator.Send(new GetCompanyQuery(id));
            return result.MatchToResult(httpContext);

        })
        .WithSummary("Get company")
        .WithDescription("Returns a company")
        .WithGetResponse<CompanyDto>();
    }
}