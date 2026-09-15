using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FleetFlow.Modules.Fleet.Features.GetDriver;

public static class GetDriverEndpoint
{
    public static IEndpointRouteBuilder MapGetDriverEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/{id:guid}", async (
                Guid id,
                GetDriverHandler handler,
                CancellationToken cancellationToken) =>
            {
                var result = await handler.HandleAsync(new GetDriverQuery(id), cancellationToken);

                return result.IsFailure
                    ? Results.NotFound(new { result.Error.Code, result.Error.Message })
                    : Results.Ok(result.Value);
            })
            .WithName("GetDriver")
            .WithSummary("Gets a driver by id.")
            .Produces<GetDriverResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound);

        return endpoints;
    }
}
