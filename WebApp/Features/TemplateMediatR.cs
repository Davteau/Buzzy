using MediatR;

namespace WebApp.Features
{
    public record TemplateMediatRRequest() : IRequest<string>;

    public static class TemplateEndpoints
    {
        public static void MapTemplateEndpoints(this WebApplication app)
        {
            app.MapGet("/api/hello", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new TemplateMediatRRequest());
                return Results.Ok(result);
            });
        }
    }

    public class TemplateMediatRHandler : IRequestHandler<TemplateMediatRRequest, string>
    {
        public Task<string> Handle(TemplateMediatRRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Hello from templateMediatRHandler");
        }
    }

}

