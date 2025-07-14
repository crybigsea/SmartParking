using Prism.Navigation.Regions;
using SmartParking.Common.ViewModels;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;
        public UserViewModel(IUnityContainer unityContainer, IRegionManager regionManager) 
            : base(unityContainer, regionManager)
        {
            PageTitle = "用户管理";
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }
    }
}
