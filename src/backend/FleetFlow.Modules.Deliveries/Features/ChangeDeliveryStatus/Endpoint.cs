using FleetFlow.Shared.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Deliveries.Features.ChangeDeliveryStatus;

public static class ChangeDeliveryStatusEndpoint
{
    public static IEndpointRouteBuilder MapChangeDeliveryStatusEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/{id:guid}/status", async (
                Guid id,
                ChangeDeliveryStatusCommand command,
                ChangeDeliveryStatusHandler handler,
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
            .WithName("ChangeDeliveryStatus")
            .WithSummary("Changes the status of a delivery.")
            .Produces<ChangeDeliveryStatusResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
