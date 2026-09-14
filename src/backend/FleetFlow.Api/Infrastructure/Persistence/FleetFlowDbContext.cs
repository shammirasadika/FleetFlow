using FleetFlow.Modules.Deliveries;
using FleetFlow.Modules.Deliveries.Domain;
using FleetFlow.Modules.Deliveries.Infrastructure;
using FleetFlow.Modules.Fleet.Domain;
using FleetFlow.Modules.Fleet.Infrastructure;
using FleetFlow.Modules.Identity.Domain;
using FleetFlow.Modules.Identity.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FleetFlow.Api.Infrastructure.Persistence;

/// <summary>The single EF Core context shared across modules in the modular monolith.</summary>
public sealed class FleetFlowDbContext(DbContextOptions<FleetFlowDbContext> options)
    : DbContext(options), IDeliveriesDbContext
{
    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Driver> Drivers => Set<Driver>();

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<Delivery> Deliveries => Set<Delivery>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new DriverConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new DeliveryConfiguration());
    }
}
