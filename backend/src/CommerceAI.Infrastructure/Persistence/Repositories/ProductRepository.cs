using CommerceAI.Domain.Entities;
using CommerceAI.Domain.Interfaces;
using CommerceAI.Infrastructure.Persistence;

namespace CommerceAI.Infrastructure.Persistence.Repositories;

public sealed class ProductRepository(ApplicationDbContext context) : IProductRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(
    Product product,
    CancellationToken cancellationToken = default)
    {
        await _context.Products.AddAsync(product, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}