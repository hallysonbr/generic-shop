using GenericShop.Services.Orders.Application.DTOs.ViewModels;
using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using GenericShop.Services.Orders.Infra.CacheStorage.Interfaces;
using MediatR;

namespace GenericShop.Services.Orders.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICacheService _cacheService;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, ICacheService cacheService)
        {
            _orderRepository = orderRepository;
            _cacheService = cacheService;
        }

        public async Task<OrderViewModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = request.Id.ToString();
            var orderVm = await _cacheService.GetAsync<OrderViewModel>(cacheKey);

            if (orderVm is null)
            {
                var order = await _orderRepository.GetByIdAsync(request.Id);
                orderVm = OrderViewModel.FromEntity(order);

                await _cacheService.SetAsync(cacheKey, orderVm);
            }           

            return orderVm;
        }
    }
}
