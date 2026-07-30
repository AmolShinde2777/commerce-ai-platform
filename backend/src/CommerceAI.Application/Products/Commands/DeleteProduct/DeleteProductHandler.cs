using CommerceAI.Domain.Interfaces;

namespace CommerceAI.Application.Products.Commands.DeleteProduct;

public sealed class DeleteProductHandler
{
    private readonly IProductRepository _productRepository;

    public DeleteProductHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> HandleAsync(
        DeleteProductCommand command,
        CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(
            command.Id,
            cancellationToken);

        if (product is null)
        {
            return false;
        }

        await _productRepository.DeleteAsync(
            product,
            cancellationToken);

        return true;
    }
}