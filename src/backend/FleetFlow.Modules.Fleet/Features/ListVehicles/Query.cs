using FleetFlow.Modules.Fleet.Domain;

namespace FleetFlow.Modules.Fleet.Features.ListVehicles;

public sealed record ListVehiclesQuery(
    Guid? CompanyId,
    VehicleStatus? Status,
    int Page,
    int PageSize);
