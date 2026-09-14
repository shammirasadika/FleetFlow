using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.CreateDelivery;

public sealed record CreateDeliveryResponse(
    Guid Id,
    Guid CompanyId,
    string CustomerName,
    string CustomerPhone,
    string PickupAddress,
    string DeliveryAddress,
    DateTime ScheduledDate,
    DeliveryPriority Priority,
    DeliveryStatus Status,
    DateTime CreatedAt)
{
    public static CreateDeliveryResponse FromDelivery(Delivery delivery) => new(
        delivery.Id,
        delivery.CompanyId,
        delivery.CustomerName,
        delivery.CustomerPhone,
        delivery.PickupAddress,
        delivery.DeliveryAddress,
        delivery.ScheduledDate,
        delivery.Priority,
        delivery.Status,
        delivery.CreatedAt);
}
