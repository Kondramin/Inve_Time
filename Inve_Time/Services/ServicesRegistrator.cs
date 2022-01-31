using Inve_Time.Services.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection RegistrateServices(this IServiceCollection services) => services
            .AddServices()
            .AddTransient<IUserDialog, UserDialogService>()
            .AddTransient<IShowPasswordWindowsService, ShowPasswordWindowsService>()
            .AddScoped<IEditPasswordService, EditPasswordService>()
            ;
    }
}
