namespace GenericShop.Services.Notifications.Domain.DTOs
{
    public class EmailTemplateDto
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Event { get; set; }
    }
}
