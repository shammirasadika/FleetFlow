using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Deliveries.Features.CreateDelivery;

public static class CreateDeliveryValidator
{
    public static Result Validate(CreateDeliveryCommand command)
    {
        if (command.CompanyId == Guid.Empty)
        {
            return Result.Failure(Error.Validation("CreateDelivery.CompanyId", "CompanyId is required."));
        }

        if (string.IsNullOrWhiteSpace(command.CustomerName))
        {
            return Result.Failure(Error.Validation("CreateDelivery.CustomerName", "Customer name is required."));
        }

        if (string.IsNullOrWhiteSpace(command.CustomerPhone))
        {
            return Result.Failure(Error.Validation("CreateDelivery.CustomerPhone", "Customer phone is required."));
        }

        if (string.IsNullOrWhiteSpace(command.PickupAddress))
        {
            return Result.Failure(Error.Validation("CreateDelivery.PickupAddress", "Pickup address is required."));
        }

        if (string.IsNullOrWhiteSpace(command.DeliveryAddress))
        {
            return Result.Failure(Error.Validation("CreateDelivery.DeliveryAddress", "Delivery address is required."));
        }

        if (command.ScheduledDate <= DateTime.UtcNow)
        {
            return Result.Failure(Error.Validation("CreateDelivery.ScheduledDate", "Scheduled date must be in the future."));
        }

        return Result.Success();
    }
}
