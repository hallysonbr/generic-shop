using GenericShop.Services.Notifications.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Notifications.Domain.Interfaces.Repositories
{
    public interface IMailRepository
    {
        Task<EmailTemplateDto> GetTemplate(string @event);
    }
}
