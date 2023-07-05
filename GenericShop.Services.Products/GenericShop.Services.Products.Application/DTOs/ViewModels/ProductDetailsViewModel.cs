using GenericShop.Services.Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Application.DTOs.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel(Guid id, string title, string description, decimal price, int quantity)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public static ProductDetailsViewModel FromEntity(Product product)
        {
            return new ProductDetailsViewModel(
                product.Id,
                product.Title,
                product.Description,
                product.Price,
                product.Quantity
            );
        }
    }
}
