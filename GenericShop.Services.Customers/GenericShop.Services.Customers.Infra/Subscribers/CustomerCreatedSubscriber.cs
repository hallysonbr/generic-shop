using GenericShop.Services.Customers.Infra.MessageBus;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using GenericShop.Services.Customers.Infra.MessageBus.IntegrationEvents;

namespace GenericShop.Services.Customers.Infra.Subscribers
{
    public class CustomerCreatedSubscriber : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string QueueName = "customers-service/customers.CustomerCreatedIntegration";

        public CustomerCreatedSubscriber(IServiceProvider serviceProvider, ProducerConnection producerConnection)
        {
            _serviceProvider = serviceProvider;
            _connection = producerConnection.Connection;

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(QueueName, false, false, false, null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (sender, eventArgs) => 
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonConvert.DeserializeObject<CustomerCreatedIntegration>(contentString);

                Console.WriteLine($"Message CustomerCreatedIntegration received with Id {message.Id}");

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(QueueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
