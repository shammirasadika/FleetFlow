using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.AssignVehicle;

public sealed record AssignVehicleResponse(
    Guid Id,
    Guid? DriverId,
    Guid? VehicleId,
    DeliveryStatus Status)
{
    public static AssignVehicleResponse FromDelivery(Delivery delivery) => new(
        delivery.Id,
        delivery.DriverId,
        delivery.VehicleId,
        delivery.Status);
}
