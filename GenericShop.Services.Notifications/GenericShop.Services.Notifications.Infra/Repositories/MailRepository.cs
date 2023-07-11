using GenericShop.Services.Notifications.Domain.DTOs;
using GenericShop.Services.Notifications.Domain.Interfaces.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Notifications.Infra.Repositories
{
    public class MailRepository : IMailRepository
    {
        private readonly IMongoCollection<EmailTemplateDto> _collection;

        public MailRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<EmailTemplateDto>("email-templates");
        }

        public async Task<EmailTemplateDto> GetTemplate(string @event)
        {
            return await _collection.Find(c => c.Event == @event).SingleOrDefaultAsync();
        }
    }
}
