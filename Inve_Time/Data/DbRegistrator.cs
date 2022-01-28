using Inve_Time.DataBase.Context;
using Inve_Time.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Inve_Time.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<InveTimeDB>(opt =>
            {
                var type = Configuration["Type"];
                if (type == "MSSQL") opt.UseSqlServer(Configuration.GetConnectionString(type));
                else throw new InvalidOperationException($"Тип подключения {type} не поддерживается");
            })
            .AddTransient<DbInitializer>()
            .AddRepositoriesInDb()
            ;
    }
}
