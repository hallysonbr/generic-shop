using GenericShop.Services.Products.Application.DTOs;
using MediatR;

namespace GenericShop.Services.Products.Application.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryDto Category { get; set; }
    }
}
