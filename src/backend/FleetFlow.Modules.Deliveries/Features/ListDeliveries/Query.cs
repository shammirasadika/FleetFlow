using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.ListDeliveries;

public sealed record ListDeliveriesQuery(
    Guid? CompanyId,
    DeliveryStatus? Status,
    int Page,
    int PageSize);
