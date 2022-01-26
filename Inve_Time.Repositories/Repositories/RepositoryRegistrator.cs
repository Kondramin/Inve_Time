using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Repositories;
using Inve_Time.Repositories.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Employee>, EmployeeRepository>()
            .AddTransient<IRepository<Position>, PositionRepository>()
            .AddTransient<IRepository<Product>, ProductRepository>()
            .AddTransient<IRepository<ProductInvented>, ProductInventedRepository>()
            .AddTransient<IRepository<Category>, CategoryRepository>()
            .AddTransient<IRepository<InventoryEvent>, InventoryEventRepository>()
            .AddTransient<IRepository<CategorySearchWord>, CategorySearchWordRepository>()
            .AddTransient<IRepository<Password>, DbRepository<Password>>()
            ;
    }
}
