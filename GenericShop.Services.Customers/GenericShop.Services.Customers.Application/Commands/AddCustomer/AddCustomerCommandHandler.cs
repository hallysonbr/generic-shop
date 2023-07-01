using GenericShop.Services.Customers.Domain.Entities;
using GenericShop.Services.Customers.Domain.Interfaces.Repositories;
using GenericShop.Services.Customers.Infra.MessageBus.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Application.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Guid>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEventProcessor _eventProcessor;

        public AddCustomerCommandHandler(ICustomerRepository repository, IEventProcessor eventProcessor)
        {
            _repository = repository;
            _eventProcessor = eventProcessor;
        }

        public async Task<Guid> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.FullName, request.BirthDate, request.Email);

            await _repository.AddAsync(customer);

            _eventProcessor.Process(customer.Events);

            return customer.Id;
        }
    }
}
