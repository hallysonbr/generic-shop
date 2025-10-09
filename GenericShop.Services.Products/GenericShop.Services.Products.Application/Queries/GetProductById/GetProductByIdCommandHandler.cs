using GenericShop.Services.Products.Application.DTOs.ViewModels;
using GenericShop.Services.Products.Domain.Interfaces.Repositories;
using MediatR;

namespace GenericShop.Services.Products.Application.Queries.GetProductById
{
    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, ProductDetailsViewModel>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDetailsViewModel> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            var productDetails = ProductDetailsViewModel.FromEntity(product);

            return productDetails;
        }
    }
}
