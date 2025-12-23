using CapcoTechnicalTest.Domain.Customers;
using CapcoTechnicalTest.Domain.Pricing;
using CapcoTechnicalTest.Domain.Shared;
using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Application.Carts;

public sealed class CartTotalCalculator : ICartTotalCalculator
{
    private readonly IPricePolicy _pricePolicy;

    public CartTotalCalculator(IPricePolicy pricePolicy)
    {
        _pricePolicy = pricePolicy ?? throw new ArgumentNullException(nameof(pricePolicy));
    }

    public Money CalculateTotal(Customer customer, ShoppingCart cart)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        if (cart is null)
        {
            throw new ArgumentNullException(nameof(cart));
        }

        var total = Money.Zero;

        foreach (var item in cart.Items)
        {
            var unitPrice = _pricePolicy.GetUnitPrice(customer, item.ProductType);
            total += unitPrice * item.Quantity;
        }

        return total;
    }
}
