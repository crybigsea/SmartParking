using Prism.Navigation.Regions;
using SmartParking.Common.ViewModels;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;

        public MenuViewModel(
            IUnityContainer unityContainer,
            IRegionManager regionManager)
            : base(unityContainer, regionManager)
        {
            PageTitle = "菜单管理";
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }
    }
}
