using GenericShop.Services.Products.Domain.Interfaces.Repositories;
using GenericShop.Services.Products.Infra.MongoDB;
using GenericShop.Services.Products.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Infra
{
    public static class Injector
    {
        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton(sp => {
                var configuration = sp.GetService<IConfiguration>();

                var options = new MongoDBOptions();
                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton(sp => {
                var options = sp.GetService<MongoDBOptions>();

                return new MongoClient(options.ConnectionString);
            });

            services.AddTransient(sp => {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDBOptions>();
                var mongoClient = sp.GetService<MongoClient>();

                return mongoClient.GetDatabase(options.Database);
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
