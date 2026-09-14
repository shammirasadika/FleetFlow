namespace FleetFlow.Modules.Fleet.Domain;

/// <summary>A driver employed by a company, eligible to be assigned to deliveries.</summary>
public class Driver
{
    public Guid Id { get; private init; }

    public Guid CompanyId { get; private init; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string LicenceNumber { get; private set; }

    public DateTime LicenceExpiry { get; private set; }

    public DriverStatus Status { get; private set; }

    public DateTime CreatedAt { get; private init; }

    private Driver(
        Guid id,
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string licenceNumber,
        DateTime licenceExpiry,
        DriverStatus status,
        DateTime createdAt)
    {
        Id = id;
        CompanyId = companyId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        LicenceNumber = licenceNumber;
        LicenceExpiry = licenceExpiry;
        Status = status;
        CreatedAt = createdAt;
    }

    public static Driver Create(
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string licenceNumber,
        DateTime licenceExpiry)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(licenceNumber);

        return new Driver(
            Guid.NewGuid(),
            companyId,
            firstName,
            lastName,
            email,
            licenceNumber,
            licenceExpiry,
            DriverStatus.Available,
            DateTime.UtcNow);
    }

    public void ChangeStatus(DriverStatus status) => Status = status;

    private Driver()
    {
        // Required by EF Core.
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        LicenceNumber = string.Empty;
    }
}
