using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<AutorisationWindowViewModel>()
            ;
    }
}
