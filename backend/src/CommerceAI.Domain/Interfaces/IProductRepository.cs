using CommerceAI.Domain.Entities;

namespace CommerceAI.Domain.Interfaces;

public interface IProductRepository
{
    Task AddAsync(
        Product product,
        CancellationToken cancellationToken = default);
}