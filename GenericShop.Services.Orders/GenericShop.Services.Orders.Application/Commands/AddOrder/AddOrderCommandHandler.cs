using GenericShop.Services.Orders.Application.DTOs.IntegrationDtos;
using GenericShop.Services.Orders.Domain.Extensions;
using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using GenericShop.Services.Orders.Infra.MessageBus.Interfaces;
using GenericShop.Services.Orders.Infra.ServiceDiscovery.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace GenericShop.Services.Orders.Application.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBusClient _messageBus;
        private readonly IServiceDiscoveryService _serviceDiscoveryService;

        public AddOrderCommandHandler(IOrderRepository orderRepository, IMessageBusClient messageBus, IServiceDiscoveryService serviceDiscoveryService)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
            _serviceDiscoveryService = serviceDiscoveryService;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();

            var customerUrl = await _serviceDiscoveryService.GetServiceUri("CustomerServices", $"/api/customers/{order.Customer.Id}");
            var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(customerUrl);
            var stringResult = await result.Content.ReadAsStringAsync();

            var customerDto = JsonConvert.DeserializeObject<GetCustomerByIdDto>(stringResult);
            Console.Write(customerDto.FullName);

            await _orderRepository.AddAsync(order);

            foreach(var @event in order.Events) 
            {
                var routingKey = @event.GetType().Name.ToDashCase();
                _messageBus.Publish(@event, routingKey, "order-service");
            }
 
            return order.Id;
        }
    }
}
