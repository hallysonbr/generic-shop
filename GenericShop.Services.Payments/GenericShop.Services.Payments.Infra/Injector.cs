using GenericShop.Services.Payments.Infra.PaymentGateway.Interfaces;
using GenericShop.Services.Payments.Infra.PaymentGateway;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GenericShop.Services.Payments.Infra.Subscribers;
using GenericShop.Services.Payments.Infra.MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using GenericShop.Services.Payments.Domain.Interfaces.Repositories;
using GenericShop.Services.Payments.Infra.Repositories;

namespace GenericShop.Services.Payments.Infra
{
    public static class Injector
    {
        public static void AddPaymentGateway(this IServiceCollection services)
        {
            services.AddTransient<IPaymentGatewayService, MyPaymentGatewayService>();
        }

        public static void AddSubscribers(this IServiceCollection services)
        {
            services.AddHostedService<OrderCreatedSubscriber>();
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

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        }
    }
}
