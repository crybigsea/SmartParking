using Prism.Ioc;
using Prism.Modularity;
using Prism.Navigation.Regions;
using SmartParking.DashboardModule.Views;

namespace SmartParking.DashboardModule
{
    public class DashboardModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate("MainViewRegion", "DashboardView");
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DashboardView>();
        }
    }
}
