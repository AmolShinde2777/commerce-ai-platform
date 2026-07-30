namespace CommerceAI.Application.Products.Queries.GetProducts;

public sealed record ProductDto(
    Guid Id,
    string Name,
    string SKU,
    string Description,
    decimal Price,
    int QuantityInStock,
    string CategoryName,
    string ImageUrl,
    string Status);