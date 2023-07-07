using GenericShop.Services.Payments.Domain.Entities;
using GenericShop.Services.Payments.Domain.Interfaces.Repositories;
using GenericShop.Services.Payments.Infra.PaymentGateway.DTOs;
using GenericShop.Services.Payments.Infra.PaymentGateway.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GenericShop.Services.Payments.Infra.Subscribers.DTOs;
using GenericShop.Services.Payments.Domain.Events;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace GenericShop.Services.Payments.Infra.Subscribers
{
    public class OrderCreatedSubscriber : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "payment-service/order-created";
        private const string Exchange = "payment-service";
        public OrderCreatedSubscriber(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = connectionFactory.CreateConnection("payment-service-order-created-consumer");

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
                var message = JsonConvert.DeserializeObject<OrderCreated>(contentString);

                Console.WriteLine($"Message OrderCreated received with Id {message.Id}");

                var result = await ProcessPayment(message);

                if (result)
                {
                    _channel.BasicAck(eventArgs.DeliveryTag, false);

                    var paymentAccepted = new PaymentAccepted(message.Id, message.FullName, message.Email);
                    var payload = JsonConvert.SerializeObject(paymentAccepted);
                    var byteArray = Encoding.UTF8.GetBytes(payload);

                    Console.WriteLine("PaymentAccepted Published");

                    _channel.BasicPublish(Exchange, "payment-accepted", null, byteArray);
                }
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task<bool> ProcessPayment(OrderCreated orderCreated)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetService<IPaymentGatewayService>();

                var result = await paymentService
                    .Process(new CreditCardInfo(
                        orderCreated.PaymentInfo.CardNumber,
                        orderCreated.PaymentInfo.FullName,
                        orderCreated.PaymentInfo.ExpirationDate,
                        orderCreated.PaymentInfo.Cvv));

                var invoiceRepository = scope.ServiceProvider.GetService<IInvoiceRepository>();

                await invoiceRepository.AddAsync(new Invoice(orderCreated.TotalPrice, orderCreated.Id, orderCreated.PaymentInfo.CardNumber));

                return result;
            }
        }
    }
}
