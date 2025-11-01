namespace GenericShop.Services.Notifications.Application.Interfaces.Services
{
    public interface INotificationService
    {
        Task SendAsync(string subject, string content, string toEmail, string toName);
    }
}
