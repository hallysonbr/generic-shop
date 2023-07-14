using Consul;
using GenericShop.Services.Orders.Infra.ServiceDiscovery.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Infra.ServiceDiscovery
{
    public class ConsulService : IServiceDiscoveryService
    {
        private readonly IConsulClient _consulClient;
        public ConsulService(IConsulClient consulClient)
        {
            _consulClient = consulClient;   
        }

        public async Task<Uri> GetServiceUri(string serviceName, string requestUrl)
        {
            var allRegisteredService = await _consulClient.Agent.Services();

            var registeredServices = allRegisteredService.Response?.Where(s => s.Value.Service == serviceName)
                                     .Select(s => s.Value)
                                     .ToList();
            
            var service = registeredServices.First();

            Console.WriteLine(service.Address);

            var uri = $"https://{service.Address}:{service.Port}{requestUrl}";

            return new Uri(uri);
        }
    }
}
