using GenericShop.Services.Customers.Application.Commands.AddCustomer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Application
{
    public static class Injector
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(AddCustomerCommand)));
        }
    }
}
