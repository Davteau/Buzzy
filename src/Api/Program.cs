using Api.Endpoints;
using Application;
using Application.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();
builder.Services.AddApplication();

builder.Services.AddSingleton<ISingletonRandom, RandomNumberService>();
builder.Services.AddScoped<IScopedRandom, RandomNumberService>();
builder.Services.AddTransient<ITransientRandom, RandomNumberService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Application"))

);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/scalar/v1/api");
}

app.UseHttpsRedirection();
app.MapOfferingEndpoints();

app.MapGet("/random", (
            [FromServices] ISingletonRandom singleton,
            [FromServices] IScopedRandom scoped,
            [FromServices] IScopedRandom scoped2,
            [FromServices] ITransientRandom transient1,
            [FromServices] ITransientRandom transient2) =>
{
    return new
    {
        Singleton = singleton.Number,
        Scoped1 = scoped.Number,
        Scoped2 = scoped2.Number,
        Transient = transient1.Number,
        Transient2 = transient2.Number,
    };
});

app.Run();
