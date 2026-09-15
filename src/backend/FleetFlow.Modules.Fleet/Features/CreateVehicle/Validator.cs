using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Fleet.Features.CreateVehicle;

public static class CreateVehicleValidator
{
    public static Result Validate(CreateVehicleCommand command)
    {
        if (command.CompanyId == Guid.Empty)
        {
            return Result.Failure(Error.Validation("CreateVehicle.CompanyId", "CompanyId is required."));
        }

        if (string.IsNullOrWhiteSpace(command.RegistrationNumber))
        {
            return Result.Failure(
                Error.Validation("CreateVehicle.RegistrationNumber", "Registration number is required."));
        }

        if (string.IsNullOrWhiteSpace(command.Make))
        {
            return Result.Failure(Error.Validation("CreateVehicle.Make", "Make is required."));
        }

        if (string.IsNullOrWhiteSpace(command.Model))
        {
            return Result.Failure(Error.Validation("CreateVehicle.Model", "Model is required."));
        }

        if (command.Year < 1900 || command.Year > DateTime.UtcNow.Year + 1)
        {
            return Result.Failure(Error.Validation("CreateVehicle.Year", "Year is not valid."));
        }

        if (command.CurrentOdometer < 0)
        {
            return Result.Failure(
                Error.Validation("CreateVehicle.CurrentOdometer", "Current odometer cannot be negative."));
        }

        return Result.Success();
    }
}
