﻿using Prism.Container.Unity;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Refit;
using SmartParking.Client;
using SmartParking.Common;
using SmartParking.Views;
using System;
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

            containerRegistry.RegisterDialogWindow<DialogWindow>();
            Container.GetContainer().RegisterSingleton<GlobalInfo>();

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
