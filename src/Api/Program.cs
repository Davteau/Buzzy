using Api.Endpoints;
using Application;
using Application.Infrastructure.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using System;



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

app.UseHttpsRedirection();
app.MapOfferingEndpoints();

app.Run();
