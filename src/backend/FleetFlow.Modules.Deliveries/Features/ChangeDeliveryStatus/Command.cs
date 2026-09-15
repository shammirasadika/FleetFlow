using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.Modules.Deliveries.Features.ChangeDeliveryStatus;

public sealed record ChangeDeliveryStatusCommand(DeliveryStatus Status);
