using FleetFlow.Shared.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Deliveries.Features.AssignVehicle;

public static class AssignVehicleEndpoint
{
    public static IEndpointRouteBuilder MapAssignVehicleEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/{id:guid}/assign-vehicle", async (
                Guid id,
                AssignVehicleCommand command,
                AssignVehicleHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(id, command, cancellationToken);
                if (result.IsSuccess)
                {
                    return Results.Ok(result.Value);
                }

                return result.Error.Type is ErrorType.NotFound
                    ? Results.NotFound(new { result.Error.Code, result.Error.Message })
                    : Results.ValidationProblem(new Dictionary<string, string[]>
                    {
                        [result.Error.Code] = [result.Error.Message],
                    });
            })
            .WithName("AssignVehicleToDelivery")
            .WithSummary("Assigns a vehicle to a delivery.")
            .Produces<AssignVehicleResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
