using Application.Common.Behaviours;
using Application.Common.Services;
using Application.Features.Services.Validators;
using Application.Migrations;
using FluentValidation;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Application.Common;

[assembly: InternalsVisibleTo("UnitTests")]

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            options.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

        });
        services.AddValidatorsFromAssembly(typeof(CreateOfferingValidator).Assembly, includeInternalTypes: true);
        services.AddSingleton<EmailService>();
        services.AddScoped<InvitationService>();

        return services;
    }
}
