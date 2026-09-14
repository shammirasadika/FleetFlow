namespace FleetFlow.Modules.Fleet.Domain;

/// <summary>A vehicle owned by a company, eligible to be assigned to deliveries.</summary>
public class Vehicle
{
    public Guid Id { get; private init; }

    public Guid CompanyId { get; private init; }

    public string RegistrationNumber { get; private set; }

    public string Make { get; private set; }

    public string Model { get; private set; }

    public int Year { get; private set; }

    public VehicleStatus Status { get; private set; }

    public int CurrentOdometer { get; private set; }

    public DateTime CreatedAt { get; private init; }

    private Vehicle(
        Guid id,
        Guid companyId,
        string registrationNumber,
        string make,
        string model,
        int year,
        VehicleStatus status,
        int currentOdometer,
        DateTime createdAt)
    {
        Id = id;
        CompanyId = companyId;
        RegistrationNumber = registrationNumber;
        Make = make;
        Model = model;
        Year = year;
        Status = status;
        CurrentOdometer = currentOdometer;
        CreatedAt = createdAt;
    }

    public static Vehicle Create(
        Guid companyId,
        string registrationNumber,
        string make,
        string model,
        int year,
        int currentOdometer = 0)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(registrationNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(make);
        ArgumentException.ThrowIfNullOrWhiteSpace(model);

        return new Vehicle(
            Guid.NewGuid(),
            companyId,
            registrationNumber,
            make,
            model,
            year,
            VehicleStatus.Available,
            currentOdometer,
            DateTime.UtcNow);
    }

    public void ChangeStatus(VehicleStatus status) => Status = status;

    public void UpdateOdometer(int odometer)
    {
        if (odometer < CurrentOdometer)
        {
            throw new InvalidOperationException("Odometer reading cannot be lower than the current reading.");
        }

        CurrentOdometer = odometer;
    }

    private Vehicle()
    {
        // Required by EF Core.
        RegistrationNumber = string.Empty;
        Make = string.Empty;
        Model = string.Empty;
    }
}
