using FleetFlow.Modules.Fleet.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Fleet;

/// <summary>Persistence seam the Fleet module depends on; implemented by the host's DbContext.</summary>
public interface IFleetDbContext
{
    DbSet<Driver> Drivers { get; }

    DbSet<Vehicle> Vehicles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
