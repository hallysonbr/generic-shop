﻿using GenericShop.Services.Payments.Domain.Entities;
using GenericShop.Services.Payments.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Payments.Infra.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> _collection;
        public InvoiceRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<Invoice>("invoices");
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _collection.InsertOneAsync(invoice);
        }
    }
}
