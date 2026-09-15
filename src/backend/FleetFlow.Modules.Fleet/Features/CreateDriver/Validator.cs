using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Fleet.Features.CreateDriver;

public static class CreateDriverValidator
{
    public static Result Validate(CreateDriverCommand command)
    {
        if (command.CompanyId == Guid.Empty)
        {
            return Result.Failure(Error.Validation("CreateDriver.CompanyId", "CompanyId is required."));
        }

        if (string.IsNullOrWhiteSpace(command.FirstName))
        {
            return Result.Failure(Error.Validation("CreateDriver.FirstName", "First name is required."));
        }

        if (string.IsNullOrWhiteSpace(command.LastName))
        {
            return Result.Failure(Error.Validation("CreateDriver.LastName", "Last name is required."));
        }

        if (string.IsNullOrWhiteSpace(command.Email))
        {
            return Result.Failure(Error.Validation("CreateDriver.Email", "Email is required."));
        }

        if (string.IsNullOrWhiteSpace(command.LicenceNumber))
        {
            return Result.Failure(Error.Validation("CreateDriver.LicenceNumber", "Licence number is required."));
        }

        if (command.LicenceExpiry <= DateTime.UtcNow)
        {
            return Result.Failure(Error.Validation("CreateDriver.LicenceExpiry", "Licence expiry must be in the future."));
        }

        return Result.Success();
    }
}
