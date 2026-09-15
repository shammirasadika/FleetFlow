using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Deliveries.Features.AssignVehicle;

public static class AssignVehicleValidator
{
    public static Result Validate(AssignVehicleCommand command)
    {
        if (command.VehicleId == Guid.Empty)
        {
            return Result.Failure(Error.Validation("AssignVehicle.VehicleId", "VehicleId is required."));
        }

        return Result.Success();
    }
}
