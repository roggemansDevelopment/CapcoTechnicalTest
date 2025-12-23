namespace CapcoTechnicalTest.Domain.Customers;

public abstract class Customer
{
    public CustomerId Id { get; }

    protected Customer(CustomerId id)
    {
        if (string.IsNullOrWhiteSpace(id.Value))
        {
            throw new ArgumentException("Customer id is required.", nameof(id));
        }

        Id = id;
    }
}
