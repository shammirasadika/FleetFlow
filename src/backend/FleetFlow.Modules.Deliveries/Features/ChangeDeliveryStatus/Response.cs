using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.ChangeDeliveryStatus;

public sealed record ChangeDeliveryStatusResponse(Guid Id, DeliveryStatus Status)
{
    public static ChangeDeliveryStatusResponse FromDelivery(Delivery delivery) => new(delivery.Id, delivery.Status);
}
