using FleetFlow.Modules.Fleet.Features.CreateDriver;
using FleetFlow.Modules.Fleet.Features.CreateVehicle;
using FleetFlow.Modules.Fleet.Features.GetDriver;
using FleetFlow.Modules.Fleet.Features.GetVehicle;
using FleetFlow.Modules.Fleet.Features.ListDrivers;
using FleetFlow.Modules.Fleet.Features.ListVehicles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FleetFlow.Modules.Fleet;

/// <summary>Entry point for registering the Fleet module's services and endpoints.</summary>
public static class FleetModule
{
    public static IServiceCollection AddFleetModule(this IServiceCollection services)
    {
        services.AddScoped<CreateDriverHandler>();
        services.AddScoped<GetDriverHandler>();
        services.AddScoped<ListDriversHandler>();
        services.AddScoped<CreateVehicleHandler>();
        services.AddScoped<GetVehicleHandler>();
        services.AddScoped<ListVehiclesHandler>();

        return services;
    }

    public static IEndpointRouteBuilder MapFleetEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var drivers = endpoints.MapGroup("/drivers").WithTags("Drivers");
        drivers.MapCreateDriverEndpoint();
        drivers.MapGetDriverEndpoint();
        drivers.MapListDriversEndpoint();

        var vehicles = endpoints.MapGroup("/vehicles").WithTags("Vehicles");
        vehicles.MapCreateVehicleEndpoint();
        vehicles.MapGetVehicleEndpoint();
        vehicles.MapListVehiclesEndpoint();

        return endpoints;
    }
}
