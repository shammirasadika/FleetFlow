using FleetFlow.Shared.Results;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Deliveries.Features.GetDelivery;

public sealed class GetDeliveryHandler(IDeliveriesDbContext dbContext)
{
    public async Task<Result<GetDeliveryResponse>> HandleAsync(
        GetDeliveryQuery query,
        CancellationToken cancellationToken)
    {
        var delivery = await dbContext.Deliveries
            .AsNoTracking()
            .FirstOrDefaultAsync(delivery => delivery.Id == query.Id, cancellationToken);

        return delivery is null
            ? Result.Failure<GetDeliveryResponse>(
                Error.NotFound("GetDelivery.NotFound", $"Delivery '{query.Id}' was not found."))
            : Result.Success(GetDeliveryResponse.FromDelivery(delivery));
    }
}
