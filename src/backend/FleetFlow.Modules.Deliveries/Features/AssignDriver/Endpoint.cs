using FleetFlow.Shared.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Deliveries.Features.AssignDriver;

public static class AssignDriverEndpoint
{
    public static IEndpointRouteBuilder MapAssignDriverEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/{id:guid}/assign-driver", async (
                Guid id,
                AssignDriverCommand command,
                AssignDriverHandler handler,
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
            .WithName("AssignDriverToDelivery")
            .WithSummary("Assigns a driver to a delivery.")
            .Produces<AssignDriverResponse>(StatusCodes.Status200OK)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
