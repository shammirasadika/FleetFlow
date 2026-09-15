using FleetFlow.Modules.Fleet.Domain;
using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Fleet.Features.CreateVehicle;

public sealed class CreateVehicleHandler(IFleetDbContext dbContext)
{
    public async Task<Result<CreateVehicleResponse>> HandleAsync(
        CreateVehicleCommand command,
        CancellationToken cancellationToken)
    {
        var validation = CreateVehicleValidator.Validate(command);
        if (validation.IsFailure)
        {
            return Result.Failure<CreateVehicleResponse>(validation.Error);
        }

        var vehicle = Vehicle.Create(
            command.CompanyId,
            command.RegistrationNumber,
            command.Make,
            command.Model,
            command.Year,
            command.CurrentOdometer);

        dbContext.Vehicles.Add(vehicle);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(CreateVehicleResponse.FromVehicle(vehicle));
    }
}
