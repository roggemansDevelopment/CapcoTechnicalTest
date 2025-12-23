using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Domain.Customers;

public sealed record PersonName
{
    public string FirstName { get; }
    public string LastName { get; }

    public PersonName(string firstName, string lastName)
    {
        FirstName = Guard.AgainstNullOrWhiteSpace(firstName, nameof(firstName));
        LastName = Guard.AgainstNullOrWhiteSpace(lastName, nameof(lastName));
    }
}
