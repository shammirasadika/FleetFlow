using FleetFlow.Modules.Fleet.Domain;

namespace FleetFlow.Modules.Fleet.Features.ListVehicles;

public sealed record VehicleSummary(
    Guid Id,
    Guid CompanyId,
    string RegistrationNumber,
    string Make,
    string Model,
    int Year,
    VehicleStatus Status,
    int CurrentOdometer,
    DateTime CreatedAt);

public sealed record ListVehiclesResponse(
    IReadOnlyList<VehicleSummary> Items,
    int TotalCount,
    int Page,
    int PageSize);
