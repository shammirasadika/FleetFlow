using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.AssignDriver;

public sealed record AssignDriverResponse(
    Guid Id,
    Guid? DriverId,
    Guid? VehicleId,
    DeliveryStatus Status)
{
    public static AssignDriverResponse FromDelivery(Delivery delivery) => new(
        delivery.Id,
        delivery.DriverId,
        delivery.VehicleId,
        delivery.Status);
}
