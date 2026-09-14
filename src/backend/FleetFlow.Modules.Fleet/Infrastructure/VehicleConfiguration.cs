using FleetFlow.Modules.Fleet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetFlow.Modules.Fleet.Infrastructure;

public sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        builder.HasKey(vehicle => vehicle.Id);

        builder.Property(vehicle => vehicle.RegistrationNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(vehicle => vehicle.Make)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(vehicle => vehicle.Model)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(vehicle => vehicle.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.HasIndex(vehicle => new { vehicle.CompanyId, vehicle.RegistrationNumber }).IsUnique();
    }
}
