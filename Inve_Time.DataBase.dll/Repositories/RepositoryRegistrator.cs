using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Inve_Time.Interfaces.dll;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.DataBase.dll.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddScoped<IRepository<Employee>, EmployeeRepository>()
            .AddScoped<IRepository<Position>, PositionRepository>()
            .AddScoped<IRepository<ProductBase>, ProductBaseRepository>()
            .AddScoped<IRepository<ProductInvented>, ProductInventedRepository>()
            .AddScoped<IRepository<Category>, CategoryRepository>()
            .AddScoped<IRepository<InventarisationEvent>, InventarisationEventRepository>()
            .AddScoped<IRepository<CategorySearchWord>, CategorySearchWordRepository>()
            .AddScoped<IRepository<Password>, DbRepository<Password>>()
            ;
    }
}
