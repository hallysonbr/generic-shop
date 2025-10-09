using GenericShop.Services.Products.Domain.Interfaces.Repositories;
using MediatR;

namespace GenericShop.Services.Products.Application.Commands.AddProduct
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductRepository _repository;
        public AddProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.ToEntity();

            await _repository.AddAsync(product);

            return product.Id;
        }
    }
}
