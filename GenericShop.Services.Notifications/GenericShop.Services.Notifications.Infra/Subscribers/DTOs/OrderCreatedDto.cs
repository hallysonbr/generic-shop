namespace GenericShop.Services.Notifications.Infra.Subscribers.DTOs
{
    public class OrderCreatedDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
