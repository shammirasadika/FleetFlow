using FleetFlow.Modules.Deliveries.Features.CreateDelivery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FleetFlow.Modules.Deliveries;

/// <summary>Entry point for registering the Deliveries module's services and endpoints.</summary>
public static class DeliveriesModule
{
    public static IServiceCollection AddDeliveriesModule(this IServiceCollection services)
    {
        services.AddScoped<CreateDeliveryHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapDeliveriesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/deliveries").WithTags("Deliveries");

        // Placeholder proving the module is wired up; replaced by real feature endpoints later.
        group.MapGet("/", () => Results.Ok(Array.Empty<object>()))
            .WithName("GetDeliveries");

        group.MapCreateDeliveryEndpoint();

        return endpoints;
    }
}
