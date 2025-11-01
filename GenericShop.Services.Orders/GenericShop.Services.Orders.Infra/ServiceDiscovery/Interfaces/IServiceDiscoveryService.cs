namespace GenericShop.Services.Orders.Infra.ServiceDiscovery.Interfaces
{
    public interface IServiceDiscoveryService
    {
        Task<Uri> GetServiceUri(string serviceName, string requestUrl);
    }
}
