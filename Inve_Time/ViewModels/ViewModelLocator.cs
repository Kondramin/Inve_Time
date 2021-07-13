using Microsoft.Extensions.DependencyInjection;

namespace Inve_Time.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
        

    }
}
