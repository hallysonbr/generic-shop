﻿using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using GenericShop.Services.Orders.Infra.Subscribers.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Infra.Subscribers
{
    public class PaymentAcceptedSubscriber : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "order-service/payment-accepted";
        private const string Exchange = "order-service";
        private const string RoutingKey = "payment-accepted";

        public PaymentAcceptedSubscriber(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("order-service-payment-accepted-subscriber");

            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(Exchange, "topic", true);
            _channel.QueueDeclare(Queue, false, false, false, null);
            _channel.QueueBind(Queue, "payment-service", RoutingKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();

                var contentString = Encoding.UTF8.GetString(byteArray);
                var message = JsonConvert.DeserializeObject<PaymentAcceptedDto>(contentString);

                Console.WriteLine($"Message PaymentAccepted received with Id {message.Id}.");

                var result = await UpdateOrder(message);

                if (result)
                    _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task<bool> UpdateOrder(PaymentAcceptedDto paymentAccepted)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var orderRepository = scope.ServiceProvider.GetService<IOrderRepository>();

                var order = await orderRepository.GetByIdAsync(paymentAccepted.Id);

                order.SetAsCompleted();

                await orderRepository.UpdateAsync(order);

                return true;
            }
        }
    }
}
