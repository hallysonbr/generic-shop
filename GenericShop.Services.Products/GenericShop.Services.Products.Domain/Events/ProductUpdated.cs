using GenericShop.Services.Products.Domain.Interfaces.Events;

namespace GenericShop.Services.Products.Domain.Events
{
    public class ProductUpdated : IDomainEvent
    {
        public ProductUpdated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
