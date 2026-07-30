using CommerceAI.Domain.Interfaces;

namespace CommerceAI.Application.Products.Commands.UpdateProduct;

public sealed class UpdateProductHandler
{
    private readonly IProductRepository _productRepository;

    public UpdateProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> HandleAsync(
        UpdateProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(
            command.Id,
            cancellationToken);

        if (product is null)
        {
            return false;
        }

        product.UpdateName(command.Name);
        product.UpdateSku(command.SKU);
        product.UpdateDescription(command.Description);
        product.UpdatePrice(command.Price);
        product.UpdateQuantity(command.QuantityInStock);
        product.UpdateCategory(command.CategoryName);
        product.UpdateImage(command.ImageUrl);

        await _productRepository.UpdateAsync(
            product,
            cancellationToken);

        return true;
    }
}