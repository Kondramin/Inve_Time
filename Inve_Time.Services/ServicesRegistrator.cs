using Inve_Time.Interfaces.Services;
using Inve_Time.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<IAutorisationService, AutorisationService>()
            ;
    }
}
