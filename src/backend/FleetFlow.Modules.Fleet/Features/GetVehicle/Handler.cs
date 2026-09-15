using FleetFlow.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Fleet.Features.GetVehicle;

public sealed class GetVehicleHandler(IFleetDbContext dbContext)
{
    public async Task<Result<GetVehicleResponse>> HandleAsync(
        GetVehicleQuery query,
        CancellationToken cancellationToken)
    {
        var vehicle = await dbContext.Vehicles
            .AsNoTracking()
            .FirstOrDefaultAsync(vehicle => vehicle.Id == query.Id, cancellationToken);

        return vehicle is null
            ? Result.Failure<GetVehicleResponse>(
                Error.NotFound("GetVehicle.NotFound", $"Vehicle '{query.Id}' was not found."))
            : Result.Success(GetVehicleResponse.FromVehicle(vehicle));
    }
}
