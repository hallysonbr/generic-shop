using GenericShop.Services.Customers.Domain.Entities;
using GenericShop.Services.Customers.Domain.Interfaces.Repositories;
using GenericShop.Services.Customers.Infra.MongoDB.Interfaces;

namespace GenericShop.Services.Customers.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoRepository<Customer> _mongoRepository;

        public CustomerRepository(IMongoRepository<Customer> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task AddAsync(Customer customer)
        {
            await _mongoRepository.AddAsync(customer);
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _mongoRepository.GetAsync(id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _mongoRepository.UpdateAsync(customer);
        }
    }
}
