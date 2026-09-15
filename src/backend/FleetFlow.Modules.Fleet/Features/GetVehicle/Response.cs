using FleetFlow.Modules.Fleet.Domain;

namespace FleetFlow.Modules.Fleet.Features.GetVehicle;

public sealed record GetVehicleResponse(
    Guid Id,
    Guid CompanyId,
    string RegistrationNumber,
    string Make,
    string Model,
    int Year,
    VehicleStatus Status,
    int CurrentOdometer,
    DateTime CreatedAt)
{
    public static GetVehicleResponse FromVehicle(Vehicle vehicle) => new(
        vehicle.Id,
        vehicle.CompanyId,
        vehicle.RegistrationNumber,
        vehicle.Make,
        vehicle.Model,
        vehicle.Year,
        vehicle.Status,
        vehicle.CurrentOdometer,
        vehicle.CreatedAt);
}
