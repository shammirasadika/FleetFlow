using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Fleet.Features.CreateDriver;

public static class CreateDriverEndpoint
{
    public static IEndpointRouteBuilder MapCreateDriverEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/", async (
                CreateDriverCommand command,
                CreateDriverHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(command, cancellationToken);

                return result.IsFailure
                    ? Results.ValidationProblem(new Dictionary<string, string[]>
                    {
                        [result.Error.Code] = [result.Error.Message],
                    })
                    : Results.Created($"/api/drivers/{result.Value.Id}", result.Value);
            })
            .WithName("CreateDriver")
            .WithSummary("Creates a new driver.")
            .Produces<CreateDriverResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        return endpoints;
    }
}
