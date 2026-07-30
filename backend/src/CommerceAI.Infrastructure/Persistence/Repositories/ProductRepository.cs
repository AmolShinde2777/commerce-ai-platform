using CommerceAI.Domain.Entities;
using CommerceAI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IReadOnlyList<Product>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Products
        .AsNoTracking()
        .OrderBy(p => p.Name)
        .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(
    Guid id,
    CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .FirstOrDefaultAsync(
                p => p.Id == id,
                cancellationToken);
    }

    public async Task UpdateAsync(
    Product product,
    CancellationToken cancellationToken = default)
    {
        _context.Products.Update(product);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(
    Product product,
    CancellationToken cancellationToken = default)
    {
        _context.Products.Remove(product);

        await _context.SaveChangesAsync(cancellationToken);
    }
}