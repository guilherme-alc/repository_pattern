using RepositoryPattern.Repositories;
using RepositoryPattern.Repositories.Abstractions;

namespace RepositoryPattern
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
