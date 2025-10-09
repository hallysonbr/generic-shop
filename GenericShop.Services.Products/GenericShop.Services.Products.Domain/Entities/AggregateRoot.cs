using GenericShop.Services.Products.Domain.Interfaces.Entities;
using GenericShop.Services.Products.Domain.Interfaces.Events;

namespace GenericShop.Services.Products.Domain.Entities
{
    public class AggregateRoot : IEntityBase
    {
        public Guid Id { get; protected set; }

        private readonly List<IDomainEvent> _events = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}
