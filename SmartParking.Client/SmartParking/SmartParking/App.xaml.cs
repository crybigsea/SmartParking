using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Refit;
using SmartParking.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Unity;

namespace SmartParking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (!Container.Resolve<Views.LoginWindow>().ShowDialog().GetValueOrDefault())
                Application.Current.Shutdown();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(Dispatcher), obj => Application.Current.Dispatcher);

            string baseAddress = "http://localhost:4439/api/app";
            Container.GetContainer().RegisterInstance(RestService.For<ILoginService>(baseAddress));
            Container.GetContainer().RegisterInstance(RestService.For<IMenuService>(baseAddress));
            Container.GetContainer().RegisterInstance(RestService.For<IUpdateFileService>(baseAddress));
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog()
            {
                ModulePath = Environment.CurrentDirectory + "\\Modules"
            };
        }
    }
}
