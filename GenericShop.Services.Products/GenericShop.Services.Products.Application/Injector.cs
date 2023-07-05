using GenericShop.Services.Products.Application.Queries.GetAllProducts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Application
{
    public static class Injector
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(GetAllProductsCommand)));
        }
    }
}
