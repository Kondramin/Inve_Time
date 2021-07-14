using Inve_Time.Data;
using Inve_Time.Services;
using Inve_Time.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace Inve_Time
{
    public partial class App : Application
    {
        private static IHost __Host;

        public static IHost Host => __Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        public static IServiceProvider Services => Host.Services;


        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddViewModels()
            .AddServices()
            ;


        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            using (var scope = Services.CreateScope())
            {
                await scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync();
            }


            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
