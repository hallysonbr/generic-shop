using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using GenericShop.Services.Orders.Infra.MessageBus;
using GenericShop.Services.Orders.Infra.MongoDB;
using GenericShop.Services.Orders.Infra.Repositories;
using GenericShop.Services.Orders.Infra.Subscribers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using RabbitMQ.Client;

namespace GenericShop.Services.Orders.Infra
{
    public static class Injector
    {
        public static void AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(s =>
            {
                var configuration = s.GetService<IConfiguration>();
                var options = new MongoDBOptions();

                configuration.GetSection("Mongo").Bind(options);
                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var options = sp.GetService<MongoDBOptions>();
                return new MongoClient(options.ConnectionString);
            });

            services.AddTransient(sp =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDBOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                return mongoClient.GetDatabase(options.Database);
            });
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
        }

        public static void AddMessageBus(this IServiceCollection services) 
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("order-service-producer");

            services.AddSingleton(new ProducerConnection(connection));
            services.AddSingleton<IMessageBusClient, RabbitMqClient>();
        }

        public static void AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<PaymentAcceptedSubscriber>();
        }
    }
}