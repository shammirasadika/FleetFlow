using FleetFlow.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Deliveries.Features.AssignVehicle;

public sealed class AssignVehicleHandler(IDeliveriesDbContext dbContext)
{
    public async Task<Result<AssignVehicleResponse>> HandleAsync(
        Guid deliveryId,
        AssignVehicleCommand command,
        CancellationToken cancellationToken)
    {
        var validation = AssignVehicleValidator.Validate(command);
        if (validation.IsFailure)
        {
            return Result.Failure<AssignVehicleResponse>(validation.Error);
        }

        var delivery = await dbContext.Deliveries
            .FirstOrDefaultAsync(delivery => delivery.Id == deliveryId, cancellationToken);

        if (delivery is null)
        {
            return Result.Failure<AssignVehicleResponse>(
                Error.NotFound("AssignVehicle.NotFound", $"Delivery '{deliveryId}' was not found."));
        }

        delivery.AssignVehicle(command.VehicleId);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(AssignVehicleResponse.FromDelivery(delivery));
    }
}
