using GenericShop.Services.Products.Application.Queries.GetAllProducts;
using Microsoft.Extensions.DependencyInjection;

namespace GenericShop.Services.Products.Application
{
    public static class Injector
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(GetAllProductsCommand)));
        }
    }
}
