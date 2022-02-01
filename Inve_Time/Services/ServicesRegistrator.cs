using Inve_Time.Services.ServiceInterfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddGlobalServices()
            .AddTransient<IUserDialog, UserDialogService>()
            .AddTransient<IShowPasswordWindowsService, ShowPasswordWindowsService>()
            ;
    }
}
