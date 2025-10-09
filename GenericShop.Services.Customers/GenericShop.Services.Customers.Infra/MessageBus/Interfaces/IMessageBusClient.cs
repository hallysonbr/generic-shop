namespace GenericShop.Services.Customers.Infra.MessageBus.Interfaces
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}
