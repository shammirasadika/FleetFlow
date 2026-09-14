using System.Text.Json.Serialization;
using FleetFlow.Api.Infrastructure.Persistence;
using FleetFlow.Modules.Deliveries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

var connectionString =
    builder.Configuration.GetConnectionString("FleetFlow")
    ?? throw new InvalidOperationException("Connection string 'FleetFlow' is not configured.");

builder.Services.AddDbContext<FleetFlowDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure()));

builder.Services.AddScoped<IDeliveriesDbContext>(sp => sp.GetRequiredService<FleetFlowDbContext>());

builder.Services.AddDeliveriesModule();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");

var api = app.MapGroup("/api");
api.MapDeliveriesEndpoints();

app.Run();

