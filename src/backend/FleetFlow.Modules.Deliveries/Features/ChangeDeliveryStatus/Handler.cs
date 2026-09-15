using FleetFlow.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Deliveries.Features.ChangeDeliveryStatus;

public sealed class ChangeDeliveryStatusHandler(IDeliveriesDbContext dbContext)
{
    public async Task<Result<ChangeDeliveryStatusResponse>> HandleAsync(
        Guid deliveryId,
        ChangeDeliveryStatusCommand command,
        CancellationToken cancellationToken)
    {
        var validation = ChangeDeliveryStatusValidator.Validate(command);
        if (validation.IsFailure)
        {
            return Result.Failure<ChangeDeliveryStatusResponse>(validation.Error);
        }

        var delivery = await dbContext.Deliveries
            .FirstOrDefaultAsync(delivery => delivery.Id == deliveryId, cancellationToken);

        if (delivery is null)
        {
            return Result.Failure<ChangeDeliveryStatusResponse>(
                Error.NotFound("ChangeDeliveryStatus.NotFound", $"Delivery '{deliveryId}' was not found."));
        }

        delivery.ChangeStatus(command.Status);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(ChangeDeliveryStatusResponse.FromDelivery(delivery));
    }
}
