using Application.Common.Behaviours;
using Application.Features.Services.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Application.Common.Services;
using Application.Migrations;

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
