using GenericShop.Services.Orders.Domain.Interfaces.Entities;
using GenericShop.Services.Orders.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
