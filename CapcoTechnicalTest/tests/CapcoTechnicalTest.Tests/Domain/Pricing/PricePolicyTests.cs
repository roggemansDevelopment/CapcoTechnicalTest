using CapcoTechnicalTest.Domain.Pricing;
using CapcoTechnicalTest.Domain.Shared;
using CapcoTechnicalTest.Domain.Shopping;
using CapcoTechnicalTest.Tests.TestData;

namespace CapcoTechnicalTest.Tests.Domain.Pricing;

public class PricePolicyTests
{
    [Fact]
    public void GetUnitPrice_ThrowsForNullCustomer()
    {
        var policy = new PricePolicy();

        Assert.Throws<ArgumentNullException>(() => policy.GetUnitPrice(null!, ProductType.HighEndPhone));
    }

    [Fact]
    public void GetUnitPrice_ThrowsForInvalidProductType()
    {
        var policy = new PricePolicy();
        var customer = TestCustomers.CreateIndividual();

        Assert.Throws<ArgumentOutOfRangeException>(() => policy.GetUnitPrice(customer, (ProductType)999));
    }

    [Theory]
    [InlineData(ProductType.HighEndPhone, 1500)]
    [InlineData(ProductType.MidRangePhone, 800)]
    [InlineData(ProductType.Laptop, 1200)]
    public void GetUnitPrice_ReturnsConsumerPrices(ProductType productType, decimal expected)
    {
        var policy = new PricePolicy();
        var customer = TestCustomers.CreateIndividual();

        var price = policy.GetUnitPrice(customer, productType);

        Assert.Equal(Money.FromEuros(expected), price);
    }

    [Theory]
    [InlineData(ProductType.HighEndPhone, 1150)]
    [InlineData(ProductType.MidRangePhone, 600)]
    [InlineData(ProductType.Laptop, 1000)]
    public void GetUnitPrice_ReturnsSmallBusinessPrices(ProductType productType, decimal expected)
    {
        var policy = new PricePolicy();
        var customer = TestCustomers.CreateSmallBusiness();

        var price = policy.GetUnitPrice(customer, productType);

        Assert.Equal(Money.FromEuros(expected), price);
    }

    [Theory]
    [InlineData(ProductType.HighEndPhone, 1000)]
    [InlineData(ProductType.MidRangePhone, 550)]
    [InlineData(ProductType.Laptop, 900)]
    public void GetUnitPrice_ReturnsLargeBusinessPrices(ProductType productType, decimal expected)
    {
        var policy = new PricePolicy();
        var customer = TestCustomers.CreateLargeBusiness();

        var price = policy.GetUnitPrice(customer, productType);

        Assert.Equal(Money.FromEuros(expected), price);
    }

    [Theory]
    [InlineData(ProductType.HighEndPhone, 1150)]
    [InlineData(ProductType.MidRangePhone, 600)]
    [InlineData(ProductType.Laptop, 1000)]
    public void GetUnitPrice_UsesSmallBusinessPricingAtThreshold(ProductType productType, decimal expected)
    {
        var policy = new PricePolicy();
        var customer = TestCustomers.CreateSmallBusiness(10_000_000m);

        var price = policy.GetUnitPrice(customer, productType);

        Assert.Equal(Money.FromEuros(expected), price);
    }
}
