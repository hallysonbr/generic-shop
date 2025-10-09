using GenericShop.Services.Customers.Domain.Interfaces.Events;

namespace GenericShop.Services.Customers.Domain.Events
{
    public class AddressUpdated : IDomainEvent
    {
        public AddressUpdated(Guid customerId, string fullAddress)
        {
            CustomerId = customerId;
            FullAddress = fullAddress;
        }

        public Guid CustomerId { get; private set; }
        public string FullAddress { get; private set; }
    }
}
