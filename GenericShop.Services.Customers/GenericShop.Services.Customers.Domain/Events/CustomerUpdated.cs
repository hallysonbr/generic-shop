using GenericShop.Services.Customers.Domain.Interfaces.Events;
using GenericShop.Services.Customers.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Customers.Domain.Events
{
    public class CustomerUpdated : IDomainEvent
    {
        public CustomerUpdated(Guid id, string phoneNumber, Address address)
        {
            Id = id;
            Address = address;
        }

        public Guid Id { get; private set; }
        public Address Address { get; private set; }
    }
}
