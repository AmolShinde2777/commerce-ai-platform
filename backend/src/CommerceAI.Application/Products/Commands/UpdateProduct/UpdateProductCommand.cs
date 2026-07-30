namespace CommerceAI.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    string SKU,
    string Description,
    decimal Price,
    int QuantityInStock,
    string CategoryName,
    string ImageUrl);