using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SmartParking.Client.Dtos.SysUpdateInfo;
using SmartParking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Unity;
using SmartParking.Common.ViewModels;

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
