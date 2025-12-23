using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Domain.Customers;

public sealed record VatNumber
{
    public string Value { get; }

    private VatNumber(string value)
    {
        Value = value;
    }

    public static VatNumber Create(string value)
    {
        var normalized = Guard.AgainstNullOrWhiteSpace(value, nameof(value));
        return new VatNumber(normalized);
    }

    public static VatNumber? FromNullable(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return Create(value);
    }

    public override string ToString() => Value;
}
