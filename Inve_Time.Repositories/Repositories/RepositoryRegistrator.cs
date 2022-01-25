using Inve_Time.DataBase.dll.Entities;
using Inve_Time.DataBase.dll.Repositories.Base;
using Inve_Time.Interfaces.dll;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Employee>, EmployeeRepository>()
            .AddTransient<IRepository<Position>, PositionRepository>()
            .AddTransient<IRepository<ProductInfo>, ProductInfoRepository>()
            .AddTransient<IRepository<ProductInvented>, ProductInventedRepository>()
            .AddTransient<IRepository<Category>, CategoryRepository>()
            .AddTransient<IRepository<InventarisationEvent>, InventarisationEventRepository>()
            .AddTransient<IRepository<CategorySearchWord>, CategorySearchWordRepository>()
            .AddTransient<IRepository<Password>, DbRepository<Password>>()
            ;
    }
}
