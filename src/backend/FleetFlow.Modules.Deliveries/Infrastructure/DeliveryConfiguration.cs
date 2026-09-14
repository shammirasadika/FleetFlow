using FleetFlow.Modules.Deliveries.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetFlow.Modules.Deliveries.Infrastructure;

public sealed class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("Deliveries");

        builder.HasKey(delivery => delivery.Id);

        builder.Property(delivery => delivery.CustomerName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(delivery => delivery.CustomerPhone)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(delivery => delivery.PickupAddress)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(delivery => delivery.DeliveryAddress)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(delivery => delivery.Priority)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(delivery => delivery.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasIndex(delivery => delivery.CompanyId);
    }
}
