using FleetFlow.Modules.Deliveries.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Deliveries.Features.ListDeliveries;

public static class ListDeliveriesEndpoint
{
    public static IEndpointRouteBuilder MapListDeliveriesEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", async (
                ListDeliveriesHandler handler,
                CancellationToken cancellationToken,
                Guid? companyId,
                DeliveryStatus? status,
                int page = 1,
                int pageSize = 20) =>
            {
                var query = new ListDeliveriesQuery(companyId, status, page, pageSize);
                var response = await handler.HandleAsync(query, cancellationToken);

                return Results.Ok(response);
            })
            .WithName("ListDeliveries")
            .WithSummary("Lists deliveries, optionally filtered by company or status.")
            .Produces<ListDeliveriesResponse>(StatusCodes.Status200OK);

        return endpoints;
    }
}
