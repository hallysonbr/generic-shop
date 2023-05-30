using GenericShop.Services.Orders.Application.Commands.AddOrder;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
