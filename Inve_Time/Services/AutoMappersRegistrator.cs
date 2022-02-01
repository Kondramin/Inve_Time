using Inve_Time.Entities.Entities;
using Inve_Time.Interfaces.Services;
using Inve_Time.Models;
using Inve_Time.Services.AutoMappers;
using Inve_Time.Services.AutoMappers.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Services
{
    public static class AutoMappersRegistrator
    {
        public static IServiceCollection AddAutoMappers(this IServiceCollection services) => services
            .AddTransient<IAutoMapper<Category, CategoryModel>, AutoMapper<Category, CategoryModel>>()
            .AddTransient<IAutoMapper<CategorySearchWord, CategorySearchWordModel>, MappToCategorySearchWordModel>()
            ;
    }
}
