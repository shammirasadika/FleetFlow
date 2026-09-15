using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Deliveries.Features.ChangeDeliveryStatus;

public static class ChangeDeliveryStatusValidator
{
    public static Result Validate(ChangeDeliveryStatusCommand command)
    {
        if (!Enum.IsDefined(command.Status))
        {
            return Result.Failure(
                Error.Validation("ChangeDeliveryStatus.Status", "Status is not a valid delivery status."));
        }

        return Result.Success();
    }
}
