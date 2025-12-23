using CapcoTechnicalTest.Domain.Customers;

namespace CapcoTechnicalTest.Tests.Domain.Customers;

public class VatNumberTests
{
    [Fact]
    public void Create_ThrowsForNull()
    {
        Assert.Throws<ArgumentException>(() => VatNumber.Create(null!));
    }

    [Fact]
    public void Create_ThrowsForWhitespace()
    {
        Assert.Throws<ArgumentException>(() => VatNumber.Create("   "));
    }

    [Fact]
    public void Create_TrimsWhitespace()
    {
        var vatNumber = VatNumber.Create("  VAT-123 ");

        Assert.Equal("VAT-123", vatNumber.Value);
    }

    [Fact]
    public void FromNullable_ReturnsNullForNull()
    {
        var vatNumber = VatNumber.FromNullable(null);

        Assert.Null(vatNumber);
    }

    [Fact]
    public void FromNullable_ReturnsNullForWhitespace()
    {
        var vatNumber = VatNumber.FromNullable("   ");

        Assert.Null(vatNumber);
    }
}
