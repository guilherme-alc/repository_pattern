using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Abstractions;

namespace RepositoryPattern.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product product, CancellationToken cancellationToken)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }

        public async Task<Product> Delete(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }

        public async Task<List<Product>?> GetAll(CancellationToken cancellationToken, int skip = 0, int take = 25)
        {
            return await _context.Products
                .AsNoTracking()
                .OrderByDescending(p => p.CreateDate)
                .Skip(skip)
                .Take(take)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetById(int id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<Product> Update(Product product, CancellationToken cancellationToken)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }
    }
}
