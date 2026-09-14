using FleetFlow.Modules.Deliveries.Domain;
using FleetFlow.Shared.Results;

namespace FleetFlow.Modules.Deliveries.Features.CreateDelivery;

public sealed class CreateDeliveryHandler(IDeliveriesDbContext dbContext)
{
    public async Task<Result<CreateDeliveryResponse>> HandleAsync(
        CreateDeliveryCommand command,
        CancellationToken cancellationToken)
    {
        var validation = CreateDeliveryValidator.Validate(command);
        if (validation.IsFailure)
        {
            return Result.Failure<CreateDeliveryResponse>(validation.Error);
        }

        var delivery = Delivery.Create(
            command.CompanyId,
            command.CustomerName,
            command.CustomerPhone,
            command.PickupAddress,
            command.DeliveryAddress,
            command.ScheduledDate,
            command.Priority);

        dbContext.Deliveries.Add(delivery);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Success(CreateDeliveryResponse.FromDelivery(delivery));
    }
}
