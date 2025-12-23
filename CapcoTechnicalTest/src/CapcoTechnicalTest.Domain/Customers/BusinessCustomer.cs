using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Domain.Customers;

public sealed class BusinessCustomer : Customer
{
    public string CompanyName { get; }
    public CompanyRegistrationNumber RegistrationNumber { get; }
    public VatNumber? VatNumber { get; }
    public Money AnnualRevenue { get; }

    public BusinessCustomer(
        CustomerId id,
        string companyName,
        CompanyRegistrationNumber registrationNumber,
        Money annualRevenue,
        VatNumber? vatNumber = null)
        : base(id)
    {
        CompanyName = Guard.AgainstNullOrWhiteSpace(companyName, nameof(companyName));
        RegistrationNumber = Guard.AgainstNull(registrationNumber, nameof(registrationNumber));
        AnnualRevenue = annualRevenue;
        VatNumber = vatNumber;
    }
}
