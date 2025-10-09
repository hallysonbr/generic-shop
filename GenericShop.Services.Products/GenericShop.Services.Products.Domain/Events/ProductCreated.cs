using GenericShop.Services.Products.Domain.Interfaces.Events;

namespace GenericShop.Services.Products.Domain.Events
{
    public class ProductCreated : IDomainEvent
    {
        public ProductCreated(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Description { get; private set; }
    }
}
