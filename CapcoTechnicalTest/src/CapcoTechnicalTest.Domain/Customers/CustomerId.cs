using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Domain.Customers;

public readonly record struct CustomerId
{
    public string Value { get; }

    private CustomerId(string value)
    {
        Value = value;
    }

    public static CustomerId Create(string value)
    {
        var normalized = Guard.AgainstNullOrWhiteSpace(value, nameof(value));
        return new CustomerId(normalized);
    }

    public override string ToString() => Value;
}
