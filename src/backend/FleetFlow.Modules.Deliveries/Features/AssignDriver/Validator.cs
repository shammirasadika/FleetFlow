using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Deliveries.Features.AssignDriver;

public static class AssignDriverValidator
{
    public static Result Validate(AssignDriverCommand command)
    {
        if (command.DriverId == Guid.Empty)
        {
            return Result.Failure(Error.Validation("AssignDriver.DriverId", "DriverId is required."));
        }

        return Result.Success();
    }
}
