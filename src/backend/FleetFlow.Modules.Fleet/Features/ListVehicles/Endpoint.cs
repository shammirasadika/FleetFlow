using FleetFlow.Modules.Fleet.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Fleet.Features.ListVehicles;

public static class ListVehiclesEndpoint
{
    public static IEndpointRouteBuilder MapListVehiclesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", async (
                ListVehiclesHandler handler,
                CancellationToken cancellationToken,
                Guid? companyId,
                VehicleStatus? status,
                int page = 1,
                int pageSize = 20) =>
            {
                var query = new ListVehiclesQuery(companyId, status, page, pageSize);
                var response = await handler.HandleAsync(query, cancellationToken);

                return Results.Ok(response);
            })
            .WithName("ListVehicles")
            .WithSummary("Lists vehicles, optionally filtered by company or status.")
            .Produces<ListVehiclesResponse>(StatusCodes.Status200OK);

        return endpoints;
    }
}
