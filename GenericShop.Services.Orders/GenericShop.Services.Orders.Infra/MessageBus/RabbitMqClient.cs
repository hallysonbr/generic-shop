﻿using GenericShop.Services.Orders.Infra.MessageBus.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Infra.MessageBus
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
            var channel = _connection.CreateModel();

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            
            var payload = JsonConvert.SerializeObject(message, settings);
            var body = Encoding.UTF8.GetBytes(payload);
            Console.WriteLine(payload);

            channel.ExchangeDeclare(exchange, "topic", true);
            channel.BasicPublish(exchange, routingKey, null, body);
        }
    }
}
