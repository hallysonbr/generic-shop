using GenericShop.Services.Products.Application.DTOs;
using GenericShop.Services.Products.Domain.Entities;
using GenericShop.Services.Products.Domain.ValueObjects;
using MediatR;

namespace GenericShop.Services.Products.Application.Commands.AddProduct
{
    public class AddProductCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public CategoryDto Category { get; set; }

        public Product ToEntity()
        {
            return new Product(Title, Description, Price, Quantity, new Category(Category.Description, Category.Subcategory));
        }
    }
}
