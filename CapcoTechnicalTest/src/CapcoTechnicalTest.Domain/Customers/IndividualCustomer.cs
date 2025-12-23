using CapcoTechnicalTest.Domain.Shared;

namespace CapcoTechnicalTest.Domain.Customers;

public sealed class IndividualCustomer : Customer
{
    public PersonName Name { get; }

    public IndividualCustomer(CustomerId id, PersonName name)
        : base(id)
    {
        Name = Guard.AgainstNull(name, nameof(name));
    }
}
