using FleetFlow.Modules.Deliveries.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Deliveries.Features.ListDeliveries;

public sealed class ListDeliveriesHandler(IDeliveriesDbContext dbContext)
{
    public async Task<ListDeliveriesResponse> HandleAsync(
        ListDeliveriesQuery query,
        CancellationToken cancellationToken)
    {
        var page = query.Page < 1 ? 1 : query.Page;
        var pageSize = query.PageSize is < 1 or > 100 ? 20 : query.PageSize;

        IQueryable<Delivery> deliveries = dbContext.Deliveries.AsNoTracking();

        if (query.CompanyId is { } companyId)
        {
            deliveries = deliveries.Where(delivery => delivery.CompanyId == companyId);
        }

        if (query.Status is { } status)
        {
            deliveries = deliveries.Where(delivery => delivery.Status == status);
        }

        var totalCount = await deliveries.CountAsync(cancellationToken);

        var items = await deliveries
            .OrderByDescending(delivery => delivery.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(delivery => new DeliverySummary(
                delivery.Id,
                delivery.CompanyId,
                delivery.CustomerName,
                delivery.CustomerPhone,
                delivery.PickupAddress,
                delivery.DeliveryAddress,
                delivery.ScheduledDate,
                delivery.Priority,
                delivery.Status,
                delivery.DriverId,
                delivery.VehicleId,
                delivery.CreatedAt))
            .ToListAsync(cancellationToken);

        return new ListDeliveriesResponse(items, totalCount, page, pageSize);
    }
}
