using FleetFlow.Modules.Deliveries.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Modules.Deliveries;

/// <summary>Persistence seam the Deliveries module depends on; implemented by the host's DbContext.</summary>
public interface IDeliveriesDbContext
{
    DbSet<Delivery> Deliveries { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
