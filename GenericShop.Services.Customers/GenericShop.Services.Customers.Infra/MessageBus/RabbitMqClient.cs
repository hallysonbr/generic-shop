using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text;
using RabbitMQ.Client;
using GenericShop.Services.Customers.Infra.MessageBus.Interfaces;

namespace GenericShop.Services.Customers.Infra.MessageBus
{
    public class RabbitMqClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        public RabbitMqClient(ProducerConnection producerConnection)
        {
            _connection = producerConnection.Connection;
        }

        public void Publish(object message, string routingKey, string exchange)
        {
            if (routingKey.Contains("-integration"))
            {
                routingKey = routingKey.Replace("-integration", "");
            }

            var channel = _connection.CreateModel();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var payload = JsonConvert.SerializeObject(message, settings);
            Console.WriteLine(payload);

            var body = Encoding.UTF8.GetBytes(payload);

            channel.ExchangeDeclare(exchange, "topic", true);

            channel.BasicPublish(exchange, routingKey, null, body);
        }
    }
}
