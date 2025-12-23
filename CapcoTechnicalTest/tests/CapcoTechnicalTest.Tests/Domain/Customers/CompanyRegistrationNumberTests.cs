using CapcoTechnicalTest.Domain.Customers;

namespace CapcoTechnicalTest.Tests.Domain.Customers;

public class CompanyRegistrationNumberTests
{
    [Fact]
    public void Create_ThrowsForNull()
    {
        Assert.Throws<ArgumentException>(() => CompanyRegistrationNumber.Create(null!));
    }

    [Fact]
    public void Create_ThrowsForWhitespace()
    {
        Assert.Throws<ArgumentException>(() => CompanyRegistrationNumber.Create("   "));
    }

    [Fact]
    public void Create_TrimsWhitespace()
    {
        var registrationNumber = CompanyRegistrationNumber.Create("  REG-1 ");

        Assert.Equal("REG-1", registrationNumber.Value);
    }
}
