namespace GenericShop.Services.Orders.Application.DTOs.InputModels
{
    public class PaymentInfoInputModel
    {
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvv { get; set; }
    }
}
