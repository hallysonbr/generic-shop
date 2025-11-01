namespace GenericShop.Services.Payments.Infra.Subscribers.DTOs
{
    public class PaymentInfo
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
