using GenericShop.Services.Products.Domain.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Domain.Events
{
    public class ProductUpdated : IDomainEvent
    {
        public ProductUpdated(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
