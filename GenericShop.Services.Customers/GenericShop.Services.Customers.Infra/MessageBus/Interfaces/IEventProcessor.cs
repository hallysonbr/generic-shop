using GenericShop.Services.Customers.Domain.Interfaces.Events;

namespace GenericShop.Services.Customers.Infra.MessageBus.Interfaces
{
    public interface IEventProcessor
    {
        void Process(IEnumerable<IDomainEvent> events);
    }
}
