using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Tests.Domain.Shared;

public class MoneyTests
{
    [Fact]
    public void FromEuros_ThrowsForNegativeAmount()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Money.FromEuros(-0.01m));
    }

    [Fact]
    public void FromEuros_AllowsZero()
    {
        var money = Money.FromEuros(0m);

        Assert.Equal(Money.Zero, money);
    }

    [Fact]
    public void Add_SumsAmounts()
    {
        var total = Money.FromEuros(10m) + Money.FromEuros(5.5m);

        Assert.Equal(Money.FromEuros(15.5m), total);
    }

    [Fact]
    public void Multiply_ThrowsForNegativeQuantity()
    {
        var money = Money.FromEuros(10m);

        Assert.Throws<ArgumentOutOfRangeException>(() => money.Multiply(-1));
    }

    [Fact]
    public void Multiply_AllowsZeroQuantity()
    {
        var money = Money.FromEuros(10m);

        var total = money.Multiply(0);

        Assert.Equal(Money.Zero, total);
    }
}
