using CommerceAI.Domain.Enums;

namespace CommerceAI.Domain.Entities;

public class Product
{
    public Guid Id { get; private set;}

    public string Name { get; private set; } = string.Empty;

    public string SKU { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int QuantityInStock { get; private set; }

    public string CategoryName { get; private set; } = string.Empty;

    public string ImageUrl { get; private set; } = string.Empty;

    public ProductStatus Status { get; private set; }

    private Product()
    {
    }
    public Product(
        Guid id,
        string name,
        string sku,
        string description,
        decimal price,
        int quantityInStock,
        string categoryName,
        string imageUrl)
    {
        Id = id;

        UpdateName(name);
        UpdateSku(sku);
        UpdateDescription(description);
        UpdatePrice(price);
        UpdateQuantity(quantityInStock);
        UpdateCategory(categoryName);
        UpdateImage(imageUrl);

        Status = ProductStatus.Draft;
    }

    public Product(string name, string sKU, string description, decimal price, int quantityInStock, string categoryName, string imageUrl)
    {
        Name = name;
        SKU = sKU;
        Description = description;
        Price = price;
        QuantityInStock = quantityInStock;
        CategoryName = categoryName;
        ImageUrl = imageUrl;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.");

        Name = name.Trim();
    }

    public void UpdateSku(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new ArgumentException("SKU is required.");

        SKU = sku.Trim().ToUpperInvariant();
    }

    public void UpdateDescription(string description)
    {
        Description = description?.Trim() ?? string.Empty;
    }

    public void UpdatePrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Price cannot be negative.");

        Price = price;
    }

    public void UpdateQuantity(int quantity)
    {
        if (quantity < 0)
            throw new ArgumentException("Quantity cannot be negative.");

        QuantityInStock = quantity;
    }

    public void UpdateCategory(string category)
    {
        CategoryName = category?.Trim() ?? string.Empty;
    }

    public void UpdateImage(string imageUrl)
    {
        ImageUrl = imageUrl?.Trim() ?? string.Empty;
    }

    public void Activate()
    {
        Status = ProductStatus.Active;
    }

    public void Archive()
    {
        Status = ProductStatus.Archived;
    }
}