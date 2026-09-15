using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Fleet.Features.GetVehicle;

public static class GetVehicleEndpoint
{
    public static IEndpointRouteBuilder MapGetVehicleEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/{id:guid}", async (
                Guid id,
                GetVehicleHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(new GetVehicleQuery(id), cancellationToken);

                return result.IsFailure
                    ? Results.NotFound(new { result.Error.Code, result.Error.Message })
                    : Results.Ok(result.Value);
            })
            .WithName("GetVehicle")
            .WithSummary("Gets a vehicle by id.")
            .Produces<GetVehicleResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
