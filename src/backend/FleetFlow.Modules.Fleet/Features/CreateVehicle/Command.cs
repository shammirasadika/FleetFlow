namespace FleetFlow.Modules.Fleet.Features.CreateVehicle;

public sealed record CreateVehicleCommand(
    Guid CompanyId,
    string RegistrationNumber,
    string Make,
    string Model,
    int Year,
    int CurrentOdometer = 0);
