using FleetFlow.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Fleet.Features.GetDriver;

public sealed class GetDriverHandler(IFleetDbContext dbContext)
{
    public async Task<Result<GetDriverResponse>> HandleAsync(
        GetDriverQuery query,
        CancellationToken cancellationToken)
    {
        var driver = await dbContext.Drivers
            .AsNoTracking()
            .FirstOrDefaultAsync(driver => driver.Id == query.Id, cancellationToken);

        return driver is null
            ? Result.Failure<GetDriverResponse>(
                Error.NotFound("GetDriver.NotFound", $"Driver '{query.Id}' was not found."))
            : Result.Success(GetDriverResponse.FromDriver(driver));
    }
}
