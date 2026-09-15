using FleetFlow.Modules.Fleet.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Fleet.Features.ListDrivers;

public static class ListDriversEndpoint
{
    public static IEndpointRouteBuilder MapListDriversEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", async (
                ListDriversHandler handler,
                CancellationToken cancellationToken,
                Guid? companyId,
                DriverStatus? status,
                int page = 1,
                int pageSize = 20) =>
            {
                var query = new ListDriversQuery(companyId, status, page, pageSize);
                var response = await handler.HandleAsync(query, cancellationToken);

                return Results.Ok(response);
            })
            .WithName("ListDrivers")
            .WithSummary("Lists drivers, optionally filtered by company or status.")
            .Produces<ListDriversResponse>(StatusCodes.Status200OK);

        return endpoints;
    }
}
