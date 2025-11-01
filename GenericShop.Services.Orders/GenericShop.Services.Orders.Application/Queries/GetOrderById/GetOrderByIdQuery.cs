using GenericShop.Services.Orders.Application.DTOs.ViewModels;
using MediatR;

namespace GenericShop.Services.Orders.Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderViewModel>
    {
        public GetOrderByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
