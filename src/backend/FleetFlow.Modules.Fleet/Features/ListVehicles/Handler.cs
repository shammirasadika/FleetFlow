using FleetFlow.Modules.Fleet.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Fleet.Features.ListVehicles;

public sealed class ListVehiclesHandler(IFleetDbContext dbContext)
{
    public async Task<ListVehiclesResponse> HandleAsync(
        ListVehiclesQuery query,
        CancellationToken cancellationToken)
    {
        var page = query.Page < 1 ? 1 : query.Page;
        var pageSize = query.PageSize is < 1 or > 100 ? 20 : query.PageSize;

        IQueryable<Vehicle> vehicles = dbContext.Vehicles.AsNoTracking();

        if (query.CompanyId is { } companyId)
        {
            vehicles = vehicles.Where(vehicle => vehicle.CompanyId == companyId);
        }

        if (query.Status is { } status)
        {
            vehicles = vehicles.Where(vehicle => vehicle.Status == status);
        }

        var totalCount = await vehicles.CountAsync(cancellationToken);

        var items = await vehicles
            .OrderByDescending(vehicle => vehicle.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(vehicle => new VehicleSummary(
                vehicle.Id,
                vehicle.CompanyId,
                vehicle.RegistrationNumber,
                vehicle.Make,
                vehicle.Model,
                vehicle.Year,
                vehicle.Status,
                vehicle.CurrentOdometer,
                vehicle.CreatedAt))
            .ToListAsync(cancellationToken);

        return new ListVehiclesResponse(items, totalCount, page, pageSize);
    }
}
