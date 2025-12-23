using CapcoTechnicalTest.Domain.Customers;
using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Tests.TestData;

internal static class TestCustomers
{
    internal static IndividualCustomer CreateIndividual(string id = "C-1")
    {
        return new IndividualCustomer(
            CustomerId.Create(id),
            new PersonName("Jane", "Doe"));
    }

    internal static BusinessCustomer CreateSmallBusiness(decimal annualRevenue = 9_000_000m)
    {
        return new BusinessCustomer(
            CustomerId.Create("B-1"),
            "Acme Corp",
            CompanyRegistrationNumber.Create("REG-123"),
            Money.FromEuros(annualRevenue),
            VatNumber.FromNullable("VAT-123"));
    }

    internal static BusinessCustomer CreateLargeBusiness(decimal annualRevenue = 10_000_001m)
    {
        return new BusinessCustomer(
            CustomerId.Create("B-2"),
            "Mega Corp",
            CompanyRegistrationNumber.Create("REG-999"),
            Money.FromEuros(annualRevenue));
    }
}
