using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Behaviours;
using Application.Features.Services.Validators;

namespace Application
{
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

            return services;
        }
    }
}
