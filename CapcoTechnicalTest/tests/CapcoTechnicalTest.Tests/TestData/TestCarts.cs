using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Tests.TestData;

internal static class TestCarts
{
    internal static ShoppingCart SingleItem(ProductType productType, int quantity)
    {
        return new ShoppingCart(new[] { new CartLineItem(productType, quantity) });
    }

    internal static ShoppingCart MixedCart()
    {
        return new ShoppingCart(new[]
        {
            new CartLineItem(ProductType.HighEndPhone, 2),
            new CartLineItem(ProductType.MidRangePhone, 1),
            new CartLineItem(ProductType.Laptop, 3),
        });
    }
}
