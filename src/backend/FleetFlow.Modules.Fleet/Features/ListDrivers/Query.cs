using FleetFlow.Modules.Fleet.Domain;

namespace FleetFlow.Modules.Fleet.Features.ListDrivers;

public sealed record ListDriversQuery(
    Guid? CompanyId,
    DriverStatus? Status,
    int Page,
    int PageSize);
