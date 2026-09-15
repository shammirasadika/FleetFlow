using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.ListDeliveries;

public sealed record DeliverySummary(
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
    DateTime CreatedAt);

public sealed record ListDeliveriesResponse(
    IReadOnlyList<DeliverySummary> Items,
    int TotalCount,
    int Page,
    int PageSize);
