using Inve_Time.Interfaces.Services;
using Inve_Time.Servises.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Servises
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IAutorisatoinService, AutorisatoinService>()
            ;
    }
}
