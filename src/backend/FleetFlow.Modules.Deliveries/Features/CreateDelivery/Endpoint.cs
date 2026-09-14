using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Deliveries.Features.CreateDelivery;

public static class CreateDeliveryEndpoint
{
    public static IEndpointRouteBuilder MapCreateDeliveryEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/", async (
                CreateDeliveryCommand command,
                CreateDeliveryHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);

                return result.IsFailure
                    ? Results.ValidationProblem(new Dictionary<string, string[]>
                    {
                        [result.Error.Code] = [result.Error.Message],
                    })
                    : Results.Created($"/api/deliveries/{result.Value.Id}", result.Value);
            })
            .WithName("CreateDelivery")
            .WithSummary("Creates a new delivery.")
            .Produces<CreateDeliveryResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        return endpoints;
    }
}
