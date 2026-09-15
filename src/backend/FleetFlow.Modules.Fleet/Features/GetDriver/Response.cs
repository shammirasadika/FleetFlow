using FleetFlow.Modules.Fleet.Domain;

namespace FleetFlow.Modules.Fleet.Features.GetDriver;

public sealed record GetDriverResponse(
    Guid Id,
    Guid CompanyId,
    string FirstName,
    string LastName,
    string Email,
    string LicenceNumber,
    DateTime LicenceExpiry,
    DriverStatus Status,
    DateTime CreatedAt)
{
    public static GetDriverResponse FromDriver(Driver driver) => new(
        driver.Id,
        driver.CompanyId,
        driver.FirstName,
        driver.LastName,
        driver.Email,
        driver.LicenceNumber,
        driver.LicenceExpiry,
        driver.Status,
        driver.CreatedAt);
}
