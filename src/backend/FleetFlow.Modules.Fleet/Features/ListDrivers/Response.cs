using FleetFlow.Modules.Fleet.Domain;

namespace FleetFlow.Modules.Fleet.Features.ListDrivers;

public sealed record DriverSummary(
    Guid Id,
    Guid CompanyId,
    string FirstName,
    string LastName,
    string Email,
    string LicenceNumber,
    DateTime LicenceExpiry,
    DriverStatus Status,
    DateTime CreatedAt);

public sealed record ListDriversResponse(
    IReadOnlyList<DriverSummary> Items,
    int TotalCount,
    int Page,
    int PageSize);
