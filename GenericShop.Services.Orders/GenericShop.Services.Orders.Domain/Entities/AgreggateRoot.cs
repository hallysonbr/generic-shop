using GenericShop.Services.Orders.Domain.Interfaces.Entities;
using GenericShop.Services.Orders.Domain.Interfaces.Events;

namespace GenericShop.Services.Orders.Domain.Entities
{
    public class AgreggateRoot : IEntityBase
    {
        private List<IDomainEvent> _events = new List<IDomainEvent>();

        public Guid Id { get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events;

        protected void AddEvent(IDomainEvent @event)
        {
            if (_events is null) _events = new List<IDomainEvent>();

            _events.Add(@event);
        }
    }
}
