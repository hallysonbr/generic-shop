using MediatR;

namespace GenericShop.Services.Customers.Application.Commands.AddCustomer
{
    public class AddCustomerCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
