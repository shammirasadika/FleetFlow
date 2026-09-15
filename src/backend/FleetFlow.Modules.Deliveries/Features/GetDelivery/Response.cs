using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.GetDelivery;

public sealed record GetDeliveryResponse(
    Guid Id,
    Guid CompanyId,
    string CustomerName,
    string CustomerPhone,
    string PickupAddress,
    string DeliveryAddress,
    DateTime ScheduledDate,
    DeliveryPriority Priority,
    DeliveryStatus Status,
    Guid? DriverId,
    Guid? VehicleId,
    DateTime CreatedAt)
{
    public static GetDeliveryResponse FromDelivery(Delivery delivery) => new(
        delivery.Id,
        delivery.CompanyId,
        delivery.CustomerName,
        delivery.CustomerPhone,
        delivery.PickupAddress,
        delivery.DeliveryAddress,
        delivery.ScheduledDate,
        delivery.Priority,
        delivery.Status,
        delivery.DriverId,
        delivery.VehicleId,
        delivery.CreatedAt);
}
