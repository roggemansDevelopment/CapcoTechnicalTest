using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Domain.Customers;

public sealed record CompanyRegistrationNumber
{
    public string Value { get; }

    private CompanyRegistrationNumber(string value)
    {
        Value = value;
    }

    public static CompanyRegistrationNumber Create(string value)
    {
        var normalized = Guard.AgainstNullOrWhiteSpace(value, nameof(value));
        return new CompanyRegistrationNumber(normalized);
    }

    public override string ToString() => Value;
}
