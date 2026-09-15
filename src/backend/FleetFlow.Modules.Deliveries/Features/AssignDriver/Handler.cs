using FleetFlow.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Deliveries.Features.AssignDriver;

public sealed class AssignDriverHandler(IDeliveriesDbContext dbContext)
{
    public async Task<Result<AssignDriverResponse>> HandleAsync(
        Guid deliveryId,
        AssignDriverCommand command,
        CancellationToken cancellationToken)
    {
        var validation = AssignDriverValidator.Validate(command);
        if (validation.IsFailure)
        {
            return Result.Failure<AssignDriverResponse>(validation.Error);
        }

        var delivery = await dbContext.Deliveries
            .FirstOrDefaultAsync(delivery => delivery.Id == deliveryId, cancellationToken);

        if (delivery is null)
        {
            return Result.Failure<AssignDriverResponse>(
                Error.NotFound("AssignDriver.NotFound", $"Delivery '{deliveryId}' was not found."));
        }

        delivery.AssignDriver(command.DriverId);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(AssignDriverResponse.FromDelivery(delivery));
    }
}
