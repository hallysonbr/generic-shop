namespace GenericShop.Services.Orders.Infra.CacheStorage.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T data);
    }
}
