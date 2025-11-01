namespace GenericShop.Services.Orders.Application.DTOs.InputModels
{
    public class OrderItemInputModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
