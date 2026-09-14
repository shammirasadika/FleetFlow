namespace FleetFlow.Modules.Deliveries.Domain;

public enum DeliveryStatus
{
    Created = 0,
    Assigned = 1,
    Accepted = 2,
    PickedUp = 3,
    InTransit = 4,
    Delivered = 5,
    Failed = 6,
    Cancelled = 7,
}
