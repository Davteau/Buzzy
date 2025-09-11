using Api.Endpoints;
using Application;
using Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();
builder.Services.AddApplication();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Application"))

);

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference("/scalar/v1/api");


app.MapOfferingEndpoints();

app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar/v1/api");
    return Task.CompletedTask;
});


app.Run();
