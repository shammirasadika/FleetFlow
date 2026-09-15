using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Fleet.Features.CreateVehicle;

public static class CreateVehicleEndpoint
{
    public static IEndpointRouteBuilder MapCreateVehicleEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/", async (
                CreateVehicleCommand command,
                CreateVehicleHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);

                return result.IsFailure
                    ? Results.ValidationProblem(new Dictionary<string, string[]>
                    {
                        [result.Error.Code] = [result.Error.Message],
                    })
                    : Results.Created($"/api/vehicles/{result.Value.Id}", result.Value);
            })
            .WithName("CreateVehicle")
            .WithSummary("Creates a new vehicle.")
            .Produces<CreateVehicleResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        return endpoints;
    }
}
