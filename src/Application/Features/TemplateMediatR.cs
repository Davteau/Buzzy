using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApp.Features
{
    public record TemplateMediatRRequest() : IRequest<string>;

    public class TemplateMediatRHandler : IRequestHandler<TemplateMediatRRequest, string>
    {
        public Task<string> Handle(TemplateMediatRRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Hello from templateMediatRHandler");
        }
    }

}

