using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericShop.Services.Orders.Domain.Interfaces.Entities;

namespace GenericShop.Services.Orders.Domain.Entities
{
    public class Customer : IEntityBase
    {
        public Customer(Guid id, string fullName, string email)
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
