namespace CapcoTechnicalTest.Domain.Shopping;

public sealed class ShoppingCart
{
    private readonly IReadOnlyList<CartLineItem> _items;

    public IReadOnlyList<CartLineItem> Items => _items;

    public ShoppingCart(IEnumerable<CartLineItem> items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        var materialized = items.ToList();

        if (materialized.Any(item => item is null))
        {
            throw new ArgumentException("Cart items cannot contain null entries.", nameof(items));
        }

        var distinctCount = materialized
            .Select(item => item.ProductType)
            .Distinct()
            .Count();

        if (distinctCount != materialized.Count)
        {
            throw new InvalidOperationException("Each product type can appear only once in the cart.");
        }

        _items = materialized.AsReadOnly();
    }

    public static ShoppingCart Empty => new(Array.Empty<CartLineItem>());
}
