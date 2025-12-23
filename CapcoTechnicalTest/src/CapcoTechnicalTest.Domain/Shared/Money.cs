namespace CapcoTechnicalTest.Domain.Shared;

public readonly record struct Money
{
    public decimal Amount { get; }

    private Money(decimal amount)
    {
        Amount = Guard.AgainstNegative(amount, nameof(amount));
    }

    public static Money FromEuros(decimal amount) => new(amount);

    public static Money Zero => new(0m);

    public static Money operator +(Money left, Money right) => new(left.Amount + right.Amount);

    public static Money operator *(Money money, int quantity) => money.Multiply(quantity);

    public static Money operator *(int quantity, Money money) => money.Multiply(quantity);

    public Money Multiply(int quantity)
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");
        }

        return new Money(Amount * quantity);
    }

    public override string ToString() => $"{Amount:0.00} EUR";
}
