using GenericShop.Services.Products.Application.DTOs.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Application.Queries.GetProductById
{
    public class GetProductByIdCommand : IRequest<ProductDetailsViewModel>
    {
        public GetProductByIdCommand(Guid id)
        {
            this.Id = id;

        }

        public Guid Id { get; private set; }
    }
}
