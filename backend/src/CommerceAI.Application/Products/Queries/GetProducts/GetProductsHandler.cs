using CommerceAI.Domain.Interfaces;

namespace CommerceAI.Application.Products.Queries.GetProducts;

public sealed class GetProductsHandler
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyList<ProductDto>> HandleAsync(
        GetProductsQuery query,
        CancellationToken cancellationToken = default)
    {
        var products = await _repository.GetAllAsync(cancellationToken);

        return products
            .Select(product => new ProductDto(
                product.Id,
                product.Name,
                product.SKU,
                product.Description,
                product.Price,
                product.QuantityInStock,
                product.CategoryName,
                product.ImageUrl,
                product.Status.ToString()))
            .ToList();
    }
}