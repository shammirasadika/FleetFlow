namespace FleetFlow.Modules.Fleet.Features.CreateDriver;

public sealed record CreateDriverCommand(
    Guid CompanyId,
    string FirstName,
    string LastName,
    string Email,
    string LicenceNumber,
    DateTime LicenceExpiry);
