using CommerceAI.Domain.Entities;
using CommerceAI.Domain.Interfaces;

namespace CommerceAI.Application.Products.Commands.CreateProduct;

public sealed class CreateProductHandler
{
    private readonly IProductRepository _productRepository;

    public CreateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Guid> HandleAsync(
        CreateProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var product = new Product(
            command.Name,
            command.SKU,
            command.Description,
            command.Price,
            command.QuantityInStock,
            command.CategoryName,
            command.ImageUrl);

        await _productRepository.AddAsync(product, cancellationToken);

        return product.Id;
    }
}