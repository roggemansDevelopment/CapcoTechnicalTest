using CapcoTechnicalTest.Application.Carts;
using CapcoTechnicalTest.Domain.Pricing;
using CapcoTechnicalTest.Domain.Shared;
using CapcoTechnicalTest.Domain.Shopping;
using CapcoTechnicalTest.Tests.TestData;

namespace CapcoTechnicalTest.Tests.Application.Carts;

public class CartTotalCalculatorTests
{
    [Fact]
    public void Constructor_ThrowsForNullPricePolicy()
    {
        Assert.Throws<ArgumentNullException>(() => new CartTotalCalculator(null!));
    }

    [Fact]
    public void CalculateTotal_ThrowsForNullCustomer()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());

        Assert.Throws<ArgumentNullException>(() => calculator.CalculateTotal(null!, ShoppingCart.Empty));
    }

    [Fact]
    public void CalculateTotal_ThrowsForNullCart()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());
        var customer = TestCustomers.CreateIndividual();

        Assert.Throws<ArgumentNullException>(() => calculator.CalculateTotal(customer, null!));
    }

    [Fact]
    public void CalculateTotal_ReturnsZeroForEmptyCart()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());
        var customer = TestCustomers.CreateIndividual();

        var total = calculator.CalculateTotal(customer, ShoppingCart.Empty);

        Assert.Equal(Money.Zero, total);
    }

    [Fact]
    public void CalculateTotal_SumsMixedCartForConsumer()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());
        var customer = TestCustomers.CreateIndividual();
        var cart = TestCarts.MixedCart();

        var total = calculator.CalculateTotal(customer, cart);

        Assert.Equal(Money.FromEuros(7400m), total);
    }

    [Fact]
    public void CalculateTotal_SumsMixedCartForSmallBusiness()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());
        var customer = TestCustomers.CreateSmallBusiness();
        var cart = TestCarts.MixedCart();

        var total = calculator.CalculateTotal(customer, cart);

        Assert.Equal(Money.FromEuros(5900m), total);
    }

    [Fact]
    public void CalculateTotal_SumsMixedCartForLargeBusiness()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());
        var customer = TestCustomers.CreateLargeBusiness();
        var cart = TestCarts.MixedCart();

        var total = calculator.CalculateTotal(customer, cart);

        Assert.Equal(Money.FromEuros(5250m), total);
    }

    [Fact]
    public void CalculateTotal_UsesQuantityForSingleItem()
    {
        var calculator = new CartTotalCalculator(new PricePolicy());
        var customer = TestCustomers.CreateIndividual();
        var cart = TestCarts.SingleItem(ProductType.HighEndPhone, 3);

        var total = calculator.CalculateTotal(customer, cart);

        Assert.Equal(Money.FromEuros(4500m), total);
    }
}
