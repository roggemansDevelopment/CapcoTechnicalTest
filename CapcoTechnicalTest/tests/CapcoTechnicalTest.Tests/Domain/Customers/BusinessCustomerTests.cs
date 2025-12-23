using CapcoTechnicalTest.Domain.Customers;
using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Tests.Domain.Customers;

public class BusinessCustomerTests
{
    [Fact]
    public void Constructor_ThrowsForMissingCustomerId()
    {
        var registration = CompanyRegistrationNumber.Create("REG-1");

        Assert.Throws<ArgumentException>(() => new BusinessCustomer(
            default,
            "Acme",
            registration,
            Money.FromEuros(1m)));
    }

    [Fact]
    public void Constructor_ThrowsForMissingCompanyName()
    {
        var registration = CompanyRegistrationNumber.Create("REG-1");
        var customerId = CustomerId.Create("B-1");

        Assert.Throws<ArgumentException>(() => new BusinessCustomer(
            customerId,
            " ",
            registration,
            Money.FromEuros(1m)));
    }

    [Fact]
    public void Constructor_ThrowsForMissingRegistrationNumber()
    {
        var customerId = CustomerId.Create("B-1");

        Assert.Throws<ArgumentNullException>(() => new BusinessCustomer(
            customerId,
            "Acme",
            null!,
            Money.FromEuros(1m)));
    }

    [Fact]
    public void Constructor_AllowsNullVatNumber()
    {
        var customerId = CustomerId.Create("B-1");
        var registration = CompanyRegistrationNumber.Create("REG-1");

        var customer = new BusinessCustomer(
            customerId,
            "Acme",
            registration,
            Money.FromEuros(1m));

        Assert.Null(customer.VatNumber);
    }

    [Fact]
    public void Constructor_StoresVatNumber()
    {
        var customerId = CustomerId.Create("B-1");
        var registration = CompanyRegistrationNumber.Create("REG-1");
        var vatNumber = VatNumber.Create("VAT-1");

        var customer = new BusinessCustomer(
            customerId,
            "Acme",
            registration,
            Money.FromEuros(1m),
            vatNumber);

        Assert.Equal(vatNumber, customer.VatNumber);
    }
}
