using GenericShop.Services.Customers.Infra.MessageBus.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Infra.MessageBus.IntegrationEvents
{
    public class CustomerCreatedIntegration : IEvent
    {
        public CustomerCreatedIntegration(Guid id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
