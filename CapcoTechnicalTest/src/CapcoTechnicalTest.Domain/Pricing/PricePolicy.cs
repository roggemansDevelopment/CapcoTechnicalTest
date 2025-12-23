using CapcoTechnicalTest.Domain.Customers;
using CapcoTechnicalTest.Domain.Shared;
using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Domain.Pricing;

public sealed class PricePolicy : IPricePolicy
{
    private const decimal LargeBusinessRevenueThreshold = 10_000_000m;

    public Money GetUnitPrice(Customer customer, ProductType productType)
    {
        if (customer is null)
        {
            throw new ArgumentNullException(nameof(customer));
        }

        if (!Enum.IsDefined(typeof(ProductType), productType))
        {
            throw new ArgumentOutOfRangeException(nameof(productType), "Unknown product type.");
        }

        return customer switch
        {
            IndividualCustomer => GetConsumerPrice(productType),
            BusinessCustomer business when business.AnnualRevenue.Amount > LargeBusinessRevenueThreshold =>
                GetLargeBusinessPrice(productType),
            BusinessCustomer => GetSmallBusinessPrice(productType),
            _ => throw new NotSupportedException("Unsupported customer type."),
        };
    }

    private static Money GetConsumerPrice(ProductType productType) => productType switch
    {
        ProductType.HighEndPhone => Money.FromEuros(1500m),
        ProductType.MidRangePhone => Money.FromEuros(800m),
        ProductType.Laptop => Money.FromEuros(1200m),
        _ => throw new ArgumentOutOfRangeException(nameof(productType), "Unknown product type."),
    };

    private static Money GetLargeBusinessPrice(ProductType productType) => productType switch
    {
        ProductType.HighEndPhone => Money.FromEuros(1000m),
        ProductType.MidRangePhone => Money.FromEuros(550m),
        ProductType.Laptop => Money.FromEuros(900m),
        _ => throw new ArgumentOutOfRangeException(nameof(productType), "Unknown product type."),
    };

    private static Money GetSmallBusinessPrice(ProductType productType) => productType switch
    {
        ProductType.HighEndPhone => Money.FromEuros(1150m),
        ProductType.MidRangePhone => Money.FromEuros(600m),
        ProductType.Laptop => Money.FromEuros(1000m),
        _ => throw new ArgumentOutOfRangeException(nameof(productType), "Unknown product type."),
    };
}
