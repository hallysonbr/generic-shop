using GenericShop.Services.Customers.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Infra.MessageBus.Interfaces
{
    public interface IEventProcessor
    {
        void Process(IEnumerable<IDomainEvent> events);
    }
}
