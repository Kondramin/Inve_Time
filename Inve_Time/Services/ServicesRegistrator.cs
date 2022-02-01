using Inve_Time.Interfaces.Services;
using Inve_Time.Services.LocalRealisation;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddGlobalServices()
            .AddTransient<IUserDialog, UserDialogService>()
            .AddTransient<IShowEditingPasswordWindowsService, ShowEditingPasswordWindowsService>()
            ;
    }
}
