using GenericShop.Services.Notifications.Domain.Interfaces.Repositories;
using GenericShop.Services.Notifications.Infra.MongoDB;
using GenericShop.Services.Notifications.Infra.Repositories;
using GenericShop.Services.Notifications.Infra.Subscribers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GenericShop.Services.Notifications.Infra
{
    public static class Injector
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMailRepository, MailRepository>();
        }

        public static void AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(sp => {
                var configuration = sp.GetService<IConfiguration>();
                var options = new MongoDBOptions();

                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp => {
                var options = sp.GetService<MongoDBOptions>();

                return new MongoClient(options.ConnectionString);
            });

            services.AddTransient(sp => {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDBOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                return mongoClient.GetDatabase(options.Database);
            });          
        }

        public static void AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<CustomerCreatedSubscriber>();
            services.AddHostedService<OrderCreatedSubscriber>();
            services.AddHostedService<PaymentAcceptedSubscriber>();
        }
    }
}
