using Inve_Time.DataBase.dll.Entities;
using Inve_Time.Interfaces.dll;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.DataBase.dll.Repositories
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDb(this IServiceCollection services) => services
            .AddTransient<IRepository<Employee>, EmployeeRepository>()
            .AddTransient<IRepository<Position>, PositionRepository>()
            .AddTransient<IRepository<ProductBase>, ProductBaseRepository>()
            .AddTransient<IRepository<ProductInvented>, ProductInventedRepository>()
            .AddTransient<IRepository<Category>, CategoryRepository>()
            .AddTransient<IRepository<CurrentInventarisation>, CurrentInventarisationRepository>()
            .AddTransient<IRepository<HelpCategorySearch>, HelpCategorySearchRepository>()
            ;
    }
}
