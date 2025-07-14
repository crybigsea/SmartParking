using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SmartParking.SystemModule.Views;

namespace SmartParking.SystemModule
{
    public class SystemModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("LeftMenuTreeRegion", "TreeMenuView");
            regionManager.RegisterViewWithRegion("MainHeaderRegion", "MainHeaderView");

            regionManager.RequestNavigate("MainViewRegion", "DashboardView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<TreeMenuView>();
            containerRegistry.Register<MainHeaderView>();
            containerRegistry.RegisterForNavigation<DashboardView>();
            containerRegistry.RegisterForNavigation<FileUploadView>();
            containerRegistry.RegisterForNavigation<MenuView>();
            containerRegistry.RegisterDialog<AddFileDialog>();
            containerRegistry.RegisterForNavigation<UserView>();
        }
    }
}
