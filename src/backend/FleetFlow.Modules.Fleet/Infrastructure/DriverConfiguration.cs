using FleetFlow.Modules.Fleet.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetFlow.Modules.Fleet.Infrastructure;

public sealed class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    public void Configure(EntityTypeBuilder<Driver> builder)
    {
        builder.ToTable("Drivers");

        builder.HasKey(driver => driver.Id);

        builder.Property(driver => driver.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(driver => driver.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(driver => driver.Email)
            .IsRequired()
            .HasMaxLength(256);

        builder.Property(driver => driver.LicenceNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(driver => driver.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(30);

        builder.HasIndex(driver => new { driver.CompanyId, driver.Email }).IsUnique();
    }
}
