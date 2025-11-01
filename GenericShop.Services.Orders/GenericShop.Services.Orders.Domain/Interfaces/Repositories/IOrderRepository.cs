using GenericShop.Services.Orders.Domain.Entities;

namespace GenericShop.Services.Orders.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid guid);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
    }
}
