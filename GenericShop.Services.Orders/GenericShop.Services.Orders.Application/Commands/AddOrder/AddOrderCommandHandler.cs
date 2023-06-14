using GenericShop.Services.Orders.Domain.Extensions;
using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using GenericShop.Services.Orders.Infra.MessageBus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Application.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageBusClient _messageBus;

        public AddOrderCommandHandler(IOrderRepository orderRepository, IMessageBusClient messageBus)
        {
            _orderRepository = orderRepository;
            _messageBus = messageBus;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = request.ToEntity();
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
