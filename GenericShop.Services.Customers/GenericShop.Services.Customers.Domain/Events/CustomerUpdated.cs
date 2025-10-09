using GenericShop.Services.Customers.Domain.Interfaces.Events;
using GenericShop.Services.Customers.Domain.ValueObjects;

namespace GenericShop.Services.Customers.Domain.Events
{
    public class CustomerUpdated : IDomainEvent
    {
        public CustomerUpdated(Guid id, string phoneNumber, Address address)
        {
            Id = id;
            Address = address;
        }

        public Guid Id { get; private set; }
        public Address Address { get; private set; }
    }
}
