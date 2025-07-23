using RepositoryPattern.Data;
using RepositoryPattern.Repositories.Abstractions;

namespace RepositoryPattern.Repositories
{
    public class UnitOfWork (AppDbContext context, IProductRepository productRepository) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;
        public IProductRepository ProductRepository { get; } = productRepository;

        public async Task CommitWithTransactionAsync()
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
