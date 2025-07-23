namespace RepositoryPattern.Repositories.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task CommitWithTransactionAsync();
    }
}
