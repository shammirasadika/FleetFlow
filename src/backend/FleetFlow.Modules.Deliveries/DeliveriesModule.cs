using FleetFlow.Modules.Deliveries.Features.AssignDriver;
using FleetFlow.Modules.Deliveries.Features.AssignVehicle;
using FleetFlow.Modules.Deliveries.Features.ChangeDeliveryStatus;
using FleetFlow.Modules.Deliveries.Features.CreateDelivery;
using FleetFlow.Modules.Deliveries.Features.GetDelivery;
using FleetFlow.Modules.Deliveries.Features.ListDeliveries;
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
        services.AddScoped<GetDeliveryHandler>();
        services.AddScoped<ListDeliveriesHandler>();
        services.AddScoped<AssignDriverHandler>();
        services.AddScoped<AssignVehicleHandler>();
        services.AddScoped<ChangeDeliveryStatusHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapDeliveriesEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/deliveries").WithTags("Deliveries");

        group.MapCreateDeliveryEndpoint();
        group.MapGetDeliveryEndpoint();
        group.MapListDeliveriesEndpoint();
        group.MapAssignDriverEndpoint();
        group.MapAssignVehicleEndpoint();
        group.MapChangeDeliveryStatusEndpoint();

        return endpoints;
    }
}
