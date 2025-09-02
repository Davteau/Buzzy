using Application.Common.Models;
using MediatR;
using System.Reflection.Metadata;
using WebApp.Features;

namespace WebApp.Endpoints
{

    public static class TemplateMediatREndpoints
    {
        public static void MapTemplateEndpoints(this WebApplication app)
        {
            app.MapGet("/api/hello", async (IMediator mediator) =>
            {
                Type type = typeof(ClassReflection);
                var propertiesWithAttribute = type.GetProperties()
                    .Where(prop => Attribute.IsDefined(prop, typeof(MyAttribute)))
                    .ToList();

                Console.WriteLine("Oznaczone property:");
                foreach (var prop in propertiesWithAttribute)
                {
                    Console.WriteLine($"{prop.Name} ({prop.PropertyType.Name})");
                }

                int intCount = propertiesWithAttribute.Count(p => p.PropertyType == typeof(int));
                int stringCount = propertiesWithAttribute.Count(p => p.PropertyType == typeof(string));

                Console.WriteLine($"\nIlość property typu int: {intCount}");
                Console.WriteLine($"Ilość property typu string: {stringCount}");
                var result = await mediator.Send(new TemplateMediatRRequest());
                return Results.Ok(result);
            });
        }
    }
}
