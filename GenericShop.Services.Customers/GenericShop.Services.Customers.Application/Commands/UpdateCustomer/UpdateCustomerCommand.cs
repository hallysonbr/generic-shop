using GenericShop.Services.Customers.Application.DTOs;
using MediatR;

namespace GenericShop.Services.Customers.Application.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
    }
}
