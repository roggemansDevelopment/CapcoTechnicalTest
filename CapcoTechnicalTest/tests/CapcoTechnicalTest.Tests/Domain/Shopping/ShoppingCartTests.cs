using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Tests.Domain.Shopping;

public class ShoppingCartTests
{
    [Fact]
    public void Constructor_ThrowsForNullItems()
    {
        Assert.Throws<ArgumentNullException>(() => new ShoppingCart(null!));
    }

    [Fact]
    public void Constructor_ThrowsWhenItemsContainNull()
    {
        var items = new CartLineItem?[]
        {
            new CartLineItem(ProductType.HighEndPhone, 1),
            null,
        };

        Assert.Throws<ArgumentException>(() => new ShoppingCart(items.Cast<CartLineItem>()));
    }

    [Fact]
    public void Constructor_ThrowsWhenProductTypesAreDuplicated()
    {
        var items = new[]
        {
            new CartLineItem(ProductType.HighEndPhone, 1),
            new CartLineItem(ProductType.HighEndPhone, 2),
        };

        Assert.Throws<InvalidOperationException>(() => new ShoppingCart(items));
    }

    [Fact]
    public void Empty_ReturnsCartWithNoItems()
    {
        var cart = ShoppingCart.Empty;

        Assert.Empty(cart.Items);
    }

    [Fact]
    public void Constructor_StoresItems()
    {
        var items = new[]
        {
            new CartLineItem(ProductType.MidRangePhone, 1),
            new CartLineItem(ProductType.Laptop, 2),
        };

        var cart = new ShoppingCart(items);

        Assert.Equal(2, cart.Items.Count);
        Assert.Contains(cart.Items, item => item.ProductType == ProductType.MidRangePhone);
        Assert.Contains(cart.Items, item => item.ProductType == ProductType.Laptop);
    }
}
