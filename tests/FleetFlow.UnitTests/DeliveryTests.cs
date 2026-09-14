using FleetFlow.Modules.Deliveries.Domain;

namespace FleetFlow.UnitTests;

public class DeliveryTests
{
    [Fact]
    public void Create_WithValidData_ReturnsDeliveryWithCreatedStatus()
    {
        var delivery = Delivery.Create(
            companyId: Guid.NewGuid(),
            customerName: "Jane Smith",
            customerPhone: "0400000000",
            pickupAddress: "1 Warehouse Rd",
            deliveryAddress: "2 Customer St",
            scheduledDate: DateTime.UtcNow.AddDays(1));

        Assert.Equal(DeliveryStatus.Created, delivery.Status);
    }
}

