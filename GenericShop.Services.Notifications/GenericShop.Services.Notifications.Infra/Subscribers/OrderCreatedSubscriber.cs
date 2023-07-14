using GenericShop.Services.Notifications.Application.Interfaces.Services;
using GenericShop.Services.Notifications.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using GenericShop.Services.Notifications.Infra.Subscribers.DTOs;

namespace GenericShop.Services.Notifications.Infra.Subscribers
{
    public class OrderCreatedSubscriber : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "notification-service/order-created";
        private const string Exchange = "notification-service";
        public OrderCreatedSubscriber(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("notifications-service-order-created-consumer");

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(Exchange, "topic", true);
            _channel.QueueDeclare(Queue, false, false, false, null);
            _channel.QueueBind(Queue, Exchange, Queue);

            _channel.QueueBind(Queue, "order-service", "order-created");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) => {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var message = JsonConvert.DeserializeObject<OrderCreatedDto>(contentString);

                Console.WriteLine($"Message OrderCreated received with Id {message.Id}");

                await SendEmail(message);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task<bool> SendEmail(OrderCreatedDto order)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var emailService = scope.ServiceProvider.GetService<INotificationService>();
                var mailRepository = scope.ServiceProvider.GetService<IMailRepository>();

                var template = await mailRepository.GetTemplate("OrderCreated");

                //var subject = string.Format(template.Subject, order.FullName);
                //var content = string.Format(template.Content, order.FullName, order.Id);

                //await emailService.SendAsync(subject, content, order.Email, order.FullName);

                return true;
            }
        }
    }
}
