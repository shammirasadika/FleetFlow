using FleetFlow.Modules.Fleet.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Fleet.Features.ListDrivers;

public sealed class ListDriversHandler(IFleetDbContext dbContext)
{
    public async Task<ListDriversResponse> HandleAsync(
        ListDriversQuery query,
        CancellationToken cancellationToken)
    {
        var page = query.Page < 1 ? 1 : query.Page;
        var pageSize = query.PageSize is < 1 or > 100 ? 20 : query.PageSize;

        IQueryable<Driver> drivers = dbContext.Drivers.AsNoTracking();

        if (query.CompanyId is { } companyId)
        {
            drivers = drivers.Where(driver => driver.CompanyId == companyId);
        }

        if (query.Status is { } status)
        {
            drivers = drivers.Where(driver => driver.Status == status);
        }

        var totalCount = await drivers.CountAsync(cancellationToken);

        var items = await drivers
            .OrderByDescending(driver => driver.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(driver => new DriverSummary(
                driver.Id,
                driver.CompanyId,
                driver.FirstName,
                driver.LastName,
                driver.Email,
                driver.LicenceNumber,
                driver.LicenceExpiry,
                driver.Status,
                driver.CreatedAt))
            .ToListAsync(cancellationToken);

        return new ListDriversResponse(items, totalCount, page, pageSize);
    }
}
