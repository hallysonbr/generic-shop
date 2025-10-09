using GenericShop.Services.Customers.Domain.Entities;

namespace GenericShop.Services.Customers.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
    }
}
