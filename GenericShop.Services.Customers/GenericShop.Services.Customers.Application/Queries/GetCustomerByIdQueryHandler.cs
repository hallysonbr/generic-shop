using GenericShop.Services.Customers.Application.DTOs;
using GenericShop.Services.Customers.Application.DTOs.ViewModels;
using GenericShop.Services.Customers.Domain.Interfaces.Repositories;
using MediatR;

namespace GenericShop.Services.Customers.Application.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerByIdViewModel> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);

            return new GetCustomerByIdViewModel(customer.Id, customer.FullName, customer.BirthDate, AddressDto.ToDto(customer.Address));
        }
    }
}
