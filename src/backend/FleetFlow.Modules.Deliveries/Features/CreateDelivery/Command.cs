using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.CreateDelivery;

public sealed record CreateDeliveryCommand(
    Guid CompanyId,
    string CustomerName,
    string CustomerPhone,
    string PickupAddress,
    string DeliveryAddress,
    DateTime ScheduledDate,
    DeliveryPriority Priority = DeliveryPriority.Normal);
