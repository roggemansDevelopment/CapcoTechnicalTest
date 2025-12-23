using CapcoTechnicalTest.Domain.Customers;
using CapcoTechnicalTest.Domain.Shared;
using CapcoTechnicalTest.Domain.Shopping;

namespace CapcoTechnicalTest.Application.Carts;

public interface ICartTotalCalculator
{
    Money CalculateTotal(Customer customer, ShoppingCart cart);
}
