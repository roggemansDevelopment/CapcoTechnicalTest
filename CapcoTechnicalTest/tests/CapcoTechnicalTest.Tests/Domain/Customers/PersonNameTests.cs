using CapcoTechnicalTest.Domain.Customers;

namespace CapcoTechnicalTest.Tests.Domain.Customers;

public class PersonNameTests
{
    [Fact]
    public void Constructor_ThrowsForNullFirstName()
    {
        Assert.Throws<ArgumentException>(() => new PersonName(null!, "Doe"));
    }

    [Fact]
    public void Constructor_ThrowsForNullLastName()
    {
        Assert.Throws<ArgumentException>(() => new PersonName("Jane", null!));
    }

    [Fact]
    public void Constructor_TrimsNames()
    {
        var name = new PersonName("  Jane ", " Doe ");

        Assert.Equal("Jane", name.FirstName);
        Assert.Equal("Doe", name.LastName);
    }
}
