using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using CSharpWpf.Core.Services;
using CSharpWpf.Core.ViewModels.Main;
using System.Windows.Data;
using CSharpWpf.Styles.Units;
using CSharpWpf.Core.ViewModels.Units;
using CSharpWpf.Core.Models;

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
            services.AddSingleton<CollectionViewTestViewModel>();
            services.AddSingleton<PeopleXmlService>();
            services.AddSingleton<IMenuView, CollectionViewTestView>();
            services.AddSingleton<IXmlSettingService, XmlSettingService>();

            return services.BuildServiceProvider();
        }


        #endregion DI Container
    }
}
