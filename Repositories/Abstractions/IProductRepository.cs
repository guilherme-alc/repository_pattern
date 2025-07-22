using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product, CancellationToken cancellationToken);
        Task<Product?> GetById(int id, CancellationToken cancellationToken);
        Task<List<Product>?> GetAll(CancellationToken cancellationToken, int skip, int take);
        Task<Product> Update(Product product, CancellationToken cancellationToken);
        Task<Product> Delete(Product product, CancellationToken cancellationToken);
    }
}
