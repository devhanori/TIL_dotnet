using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using CSharpWpf.Core.Services;
using CSharpWpf.Core.ViewModels.Main;

namespace CSharpWpf
{
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            this.InitializeComponent();
        }
        public new static App Current => (App)Application.Current;
        #region DI Container
        public IServiceProvider Services { get; }
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<PeopleService>();

            return services.BuildServiceProvider();
        }


        #endregion DI Container
    }
}
