using GenericShop.Services.Products.Domain.ValueObjects;

namespace GenericShop.Services.Products.Application.DTOs
{
    public class CategoryDto
    {
        public string Description { get; set; }
        public string Subcategory { get; set; }

        public Category ToValueObject()
        {
            return new Category(Description, Subcategory);
        }
    }
}
