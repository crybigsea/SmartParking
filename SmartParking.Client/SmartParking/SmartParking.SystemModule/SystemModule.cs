using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SmartParking.SystemModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.SystemModule
{
    public class SystemModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", "TreeMenuView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<TreeMenuView>();
            containerRegistry.RegisterForNavigation<FileUploadView>();
            containerRegistry.RegisterForNavigation<MenuView>();
        }
    }
}
