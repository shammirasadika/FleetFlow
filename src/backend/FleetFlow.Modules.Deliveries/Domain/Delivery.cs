namespace FleetFlow.Modules.Deliveries.Domain;

/// <summary>A delivery job requested by a customer, tracked from creation through completion.</summary>
public class Delivery
{
    public Guid Id { get; private init; }

    public Guid CompanyId { get; private init; }

    public string CustomerName { get; private set; }

    public string CustomerPhone { get; private set; }

    public string PickupAddress { get; private set; }

    public string DeliveryAddress { get; private set; }

    public DateTime ScheduledDate { get; private set; }

    public Guid? DriverId { get; private set; }

    public Guid? VehicleId { get; private set; }

    public DeliveryPriority Priority { get; private set; }

    public DeliveryStatus Status { get; private set; }

    public DateTime CreatedAt { get; private init; }

    private Delivery(
        Guid id,
        Guid companyId,
        string customerName,
        string customerPhone,
        string pickupAddress,
        string deliveryAddress,
        DateTime scheduledDate,
        DeliveryPriority priority,
        DeliveryStatus status,
        DateTime createdAt)
    {
        Id = id;
        CompanyId = companyId;
        CustomerName = customerName;
        CustomerPhone = customerPhone;
        PickupAddress = pickupAddress;
        DeliveryAddress = deliveryAddress;
        ScheduledDate = scheduledDate;
        Priority = priority;
        Status = status;
        CreatedAt = createdAt;
    }

    public static Delivery Create(
        Guid companyId,
        string customerName,
        string customerPhone,
        string pickupAddress,
        string deliveryAddress,
        DateTime scheduledDate,
        DeliveryPriority priority = DeliveryPriority.Normal)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(customerName);
        ArgumentException.ThrowIfNullOrWhiteSpace(customerPhone);
        ArgumentException.ThrowIfNullOrWhiteSpace(pickupAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(deliveryAddress);

        return new Delivery(
            Guid.NewGuid(),
            companyId,
            customerName,
            customerPhone,
            pickupAddress,
            deliveryAddress,
            scheduledDate,
            priority,
            DeliveryStatus.Created,
            DateTime.UtcNow);
    }

    public void AssignDriverAndVehicle(Guid driverId, Guid vehicleId)
    {
        if (Status is not DeliveryStatus.Created)
        {
            throw new InvalidOperationException("Only a newly created delivery can be assigned.");
        }

        DriverId = driverId;
        VehicleId = vehicleId;
        Status = DeliveryStatus.Assigned;
    }

    private Delivery()
    {
        // Required by EF Core.
        CustomerName = string.Empty;
        CustomerPhone = string.Empty;
        PickupAddress = string.Empty;
        DeliveryAddress = string.Empty;
    }
}
