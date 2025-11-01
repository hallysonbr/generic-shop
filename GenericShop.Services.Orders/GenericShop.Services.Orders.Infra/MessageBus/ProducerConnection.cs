using RabbitMQ.Client;

namespace GenericShop.Services.Orders.Infra.MessageBus
{
    public class ProducerConnection
    {
        public ProducerConnection(IConnection connection)
        {
            Connection = connection;
        }

        public IConnection Connection { get; private set; }
    }
}
