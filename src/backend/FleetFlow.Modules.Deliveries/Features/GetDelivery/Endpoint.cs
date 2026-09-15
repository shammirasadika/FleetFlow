using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Deliveries.Features.GetDelivery;

public static class GetDeliveryEndpoint
{
    public static IEndpointRouteBuilder MapGetDeliveryEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/{id:guid}", async (
                Guid id,
                GetDeliveryHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(new GetDeliveryQuery(id), cancellationToken);

                return result.IsFailure
                    ? Results.NotFound(new { result.Error.Code, result.Error.Message })
                    : Results.Ok(result.Value);
            })
            .WithName("GetDelivery")
            .WithSummary("Gets a delivery by id.")
            .Produces<GetDeliveryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
