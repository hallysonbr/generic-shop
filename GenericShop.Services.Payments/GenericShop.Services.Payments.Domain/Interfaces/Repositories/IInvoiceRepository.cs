using GenericShop.Services.Payments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Domain.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice);
    }
}
