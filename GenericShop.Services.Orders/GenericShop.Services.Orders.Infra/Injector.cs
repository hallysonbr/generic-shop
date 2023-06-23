using Consul;
using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using GenericShop.Services.Orders.Infra.MessageBus;
using GenericShop.Services.Orders.Infra.MongoDB;
using GenericShop.Services.Orders.Infra.Repositories;
using GenericShop.Services.Orders.Infra.ServiceDiscovery;
using GenericShop.Services.Orders.Infra.Subscribers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        public static void AddConsulConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                var address = configuration.GetValue<string>("Consul:Host");
                consulConfig.Address = new Uri(address);
            }));

            services.AddTransient<IServiceDiscoveryService, ConsulService>();
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var lifeTime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            var registration = new AgentServiceRegistration
            {
                ID = $"order-service-{Guid.NewGuid()}" ,
                Name = "OrderServices",
                Address = "localhost",
                Port = 5003
            };

            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            Console.WriteLine("Service Registered in Consul");

            lifeTime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
                Console.WriteLine("Service Deregistered in Consul");
            });

            return app;
        }
    }
}