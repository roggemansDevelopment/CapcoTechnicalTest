using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Tests.Domain.Shopping;

public class CartLineItemTests
{
    [Fact]
    public void Constructor_ThrowsForInvalidProductType()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CartLineItem((ProductType)999, 1));
    }

    [Fact]
    public void Constructor_ThrowsForZeroQuantity()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CartLineItem(ProductType.HighEndPhone, 0));
    }

    [Fact]
    public void Constructor_ThrowsForNegativeQuantity()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new CartLineItem(ProductType.HighEndPhone, -1));
    }

    [Fact]
    public void Constructor_SetsProductAndQuantity()
    {
        var item = new CartLineItem(ProductType.Laptop, 2);

        Assert.Equal(ProductType.Laptop, item.ProductType);
        Assert.Equal(2, item.Quantity);
    }
}
