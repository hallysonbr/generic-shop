using GenericShop.Services.Orders.Domain.Entities;
using GenericShop.Services.Orders.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Orders.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _collection;
        public OrderRepository(IMongoDatabase mongoDatabase)
        {
            _collection = mongoDatabase.GetCollection<Order>("orders");
        }

        public async Task AddAsync(Order order)
        {
            await _collection.InsertOneAsync(order);
        }

        public async Task<Order> GetByIdAsync(Guid guid)
        {
           return await _collection.Find(x => x.Id == guid).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            await _collection.ReplaceOneAsync(x => x.Id == order.Id, order);
        }
    }
}
