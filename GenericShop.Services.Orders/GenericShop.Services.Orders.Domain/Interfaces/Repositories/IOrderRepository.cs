using GenericShop.Services.Orders.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid guid);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
