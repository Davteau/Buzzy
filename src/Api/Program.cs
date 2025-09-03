using Api.Endpoints;
using Application;
using Application.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System;
using WebApp.Endpoints;
using WebApp.Features;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenApi();
builder.Services.AddApplication();

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

app.MapGet("/", () => "Hello World!")
    .WithDescription("To w odpowiedzi daje hello world")
    .Produces<string>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status400BadRequest)
    .WithSummary("Hello World endpoint");

app.UseHttpsRedirection();
app.MapTemplateEndpoints();
app.MapServiceEndpoints();

app.Run();
