using GenericShop.Services.Customers.Application.DTOs.ViewModels;
using MediatR;

namespace GenericShop.Services.Customers.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerByIdViewModel>
    {
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
