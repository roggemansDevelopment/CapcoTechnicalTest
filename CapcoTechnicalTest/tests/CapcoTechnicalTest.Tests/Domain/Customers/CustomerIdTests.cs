using CapcoTechnicalTest.Domain.Customers;

namespace CapcoTechnicalTest.Tests.Domain.Customers;

public class CustomerIdTests
{
    [Fact]
    public void Create_ThrowsForNull()
    {
        Assert.Throws<ArgumentException>(() => CustomerId.Create(null!));
    }

    [Fact]
    public void Create_ThrowsForWhitespace()
    {
        Assert.Throws<ArgumentException>(() => CustomerId.Create("   "));
    }

    [Fact]
    public void Create_TrimsWhitespace()
    {
        var customerId = CustomerId.Create("  C-42  ");

        Assert.Equal("C-42", customerId.Value);
    }
}
