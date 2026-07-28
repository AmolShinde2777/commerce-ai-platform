namespace CommerceAI.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    string SKU,
    string Description,
    decimal Price,
    int QuantityInStock,
    string CategoryName,
    string ImageUrl);