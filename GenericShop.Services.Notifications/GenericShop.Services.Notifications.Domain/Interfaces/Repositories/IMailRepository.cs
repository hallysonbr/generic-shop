using GenericShop.Services.Notifications.Domain.DTOs;

namespace GenericShop.Services.Notifications.Domain.Interfaces.Repositories
{
    public interface IMailRepository
    {
        Task<EmailTemplateDto> GetTemplate(string @event);
    }
}
