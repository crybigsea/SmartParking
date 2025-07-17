using Prism.Navigation.Regions;
using SmartParking.Client;
using SmartParking.Client.Dtos.SysMenu;
using SmartParking.Common;
using SmartParking.Common.ViewModels;
using SmartParking.SystemModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;
        private readonly IMenuService _menuService;
        private readonly GlobalInfo _globalInfo;

        public ObservableCollection<TreeMenuModel> Menus { get; set; } = new ObservableCollection<TreeMenuModel>();
        private IList<SysMenuDto> allMenus { get; set; }

        public MenuViewModel(
            IUnityContainer unityContainer,
            IRegionManager regionManager,
            IMenuService menuService,
            GlobalInfo globalInfo)
            : base(unityContainer, regionManager)
        {
            PageTitle = "菜单管理";
            _unityContainer = unityContainer;
            _regionManager = regionManager;
            _menuService = menuService;
            _globalInfo = globalInfo;

            allMenus = _menuService.GetAllMenus($"Bearer {_globalInfo.LoginUserInfo?.Token}").GetAwaiter().GetResult().items;
            FillMenus(Menus, null);
        }

        private void FillMenus(ObservableCollection<TreeMenuModel> menus, Guid? parentId)
        {
            var child = allMenus.Where(m => m.ParentId == parentId).OrderBy(m => m.Sort);
            if (child != null && child.Any())
            {
                foreach (var item in child)
                {
                    var menu = new TreeMenuModel(_regionManager)
                    {
                        MenuIcon = item.MenuIcon,
                        MenuName = item.MenuName,
                        ViewName = item.ViewName,
                        ParentId = item.ParentId,
                        Children = new ObservableCollection<TreeMenuModel>(),
                        IsExpanded = true
                    };
                    menus.Add(menu);
                    FillMenus(menu.Children, item.Id);
                }
                if (parentId.HasValue)
                    menus[menus.Count - 1].IsLastChild = true;
            }
        }
    }
}
