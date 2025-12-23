using CapcoTechnicalTest.Domain.Customers;
using CapcoTechnicalTest.Domain.Shared;
using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Domain.Pricing;

public interface IPricePolicy
{
    Money GetUnitPrice(Customer customer, ProductType productType);
}
