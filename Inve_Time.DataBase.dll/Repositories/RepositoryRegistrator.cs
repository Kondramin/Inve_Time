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
            .AddScoped<IRepository<CurrentInventarisation>, CurrentInventarisationRepository>()
            .AddScoped<IRepository<HelpCategorySearch>, HelpCategorySearchRepository>()
            .AddScoped<IRepository<Password>, DbRepository<Password>>()
            ;
    }
}
