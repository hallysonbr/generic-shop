namespace GenericShop.Services.Orders.Infra.Subscribers.DTOs
{
    public class PaymentAcceptedDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
