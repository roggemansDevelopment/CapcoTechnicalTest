using CapcoTechnicalTest.Domain.Customers;

namespace CapcoTechnicalTest.Tests.Domain.Customers;

public class IndividualCustomerTests
{
    [Fact]
    public void Constructor_ThrowsForMissingCustomerId()
    {
        var name = new PersonName("Jane", "Doe");

        Assert.Throws<ArgumentException>(() => new IndividualCustomer(default, name));
    }

    [Fact]
    public void Constructor_ThrowsForNullName()
    {
        var customerId = CustomerId.Create("C-1");

        Assert.Throws<ArgumentNullException>(() => new IndividualCustomer(customerId, null!));
    }
}
