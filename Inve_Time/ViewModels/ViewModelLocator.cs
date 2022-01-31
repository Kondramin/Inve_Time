using Inve_Time.ViewModels.WindowsViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();

        public AutorisationWindowViewModel AutorisationWindowViewModel => App.Services.GetRequiredService<AutorisationWindowViewModel>();
    }
}
