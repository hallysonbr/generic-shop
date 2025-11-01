using GenericShop.Services.Orders.Application.Commands.AddOrder;
using Microsoft.Extensions.DependencyInjection;

namespace GenericShop.Services.Orders.Application
{
    public static class Injector
    {
        public static void AddApplicationServices(this IServiceCollection services) 
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(AddOrderCommand)));
        }
    }
}
