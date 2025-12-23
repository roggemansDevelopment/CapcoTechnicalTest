namespace CapcoTechnicalTest.Domain.Shopping;

public sealed class CartLineItem
{
    public ProductType ProductType { get; }
    public int Quantity { get; }

    public CartLineItem(ProductType productType, int quantity)
    {
        if (!Enum.IsDefined(typeof(ProductType), productType))
        {
            throw new ArgumentOutOfRangeException(nameof(productType), "Unknown product type.");
        }

        if (quantity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        }

        ProductType = productType;
        Quantity = quantity;
    }
}
