using FleetFlow.Modules.Fleet.Domain;
using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Fleet.Features.CreateDriver;

public sealed class CreateDriverHandler(IFleetDbContext dbContext)
{
    public async Task<Result<CreateDriverResponse>> HandleAsync(
        CreateDriverCommand command,
        CancellationToken cancellationToken)
    {
        var validation = CreateDriverValidator.Validate(command);
        if (validation.IsFailure)
        {
            return Result.Failure<CreateDriverResponse>(validation.Error);
        }

        var driver = Driver.Create(
            command.CompanyId,
            command.FirstName,
            command.LastName,
            command.Email,
            command.LicenceNumber,
            command.LicenceExpiry);

        dbContext.Drivers.Add(driver);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(CreateDriverResponse.FromDriver(driver));
    }
}
