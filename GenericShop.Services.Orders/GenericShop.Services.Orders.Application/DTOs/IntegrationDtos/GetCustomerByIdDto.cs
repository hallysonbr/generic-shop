namespace GenericShop.Services.Orders.Application.DTOs.IntegrationDtos
{
    public class GetCustomerByIdDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressDto Address { get; set; }
    }
}
