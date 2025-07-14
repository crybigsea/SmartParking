using Prism.Navigation.Regions;
using SmartParking.Common.ViewModels;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel(IUnityContainer unityContainer, IRegionManager regionManager)
            : base(unityContainer, regionManager)
        {
            PageTitle = "Dashboard";
            CanClose = false;
        }
    }
}
