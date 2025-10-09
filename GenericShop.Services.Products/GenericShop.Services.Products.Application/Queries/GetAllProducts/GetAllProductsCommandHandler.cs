using GenericShop.Services.Products.Application.DTOs.ViewModels;
using GenericShop.Services.Products.Domain.Interfaces.Repositories;
using MediatR;

namespace GenericShop.Services.Products.Application.Queries.GetAllProducts
{
    public class GetAllProductsCommandHandler : IRequestHandler<GetAllProductsCommand, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            return products
                .Select(p => new ProductViewModel(p.Id, p.Title))
                .ToList();
        }
    }
}
