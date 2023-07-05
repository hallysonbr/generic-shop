using GenericShop.Services.Products.Application.DTOs.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericShop.Services.Products.Application.Queries.GetAllProducts
{
    public class GetAllProductsCommand : IRequest<List<ProductViewModel>>
    {
    }
}
