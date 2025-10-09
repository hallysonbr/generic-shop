using GenericShop.Services.Products.Application.DTOs.ViewModels;
using MediatR;

namespace GenericShop.Services.Products.Application.Queries.GetAllProducts
{
    public class GetAllProductsCommand : IRequest<List<ProductViewModel>>
    {
    }
}
