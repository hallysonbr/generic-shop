using System.Linq.Expressions;

namespace GenericShop.Services.Customers.Infra.MongoDB.Interfaces
{
    public interface IMongoRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
