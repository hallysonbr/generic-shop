using GenericShop.Services.Payments.Domain.Entities;

namespace GenericShop.Services.Payments.Domain.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice);
    }
}
