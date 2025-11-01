namespace GenericShop.Services.Orders.Infra.MessageBus.Interfaces
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}
