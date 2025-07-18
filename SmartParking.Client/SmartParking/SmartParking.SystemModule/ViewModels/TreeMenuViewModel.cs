using Prism.Commands;
using Prism.Navigation.Regions;
using SmartParking.Client;
using SmartParking.Client.Dtos.SysMenu;
using SmartParking.Common;
using SmartParking.SystemModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SmartParking.SystemModule.ViewModels
{
    public class TreeMenuViewModel
    {
        private IRegionManager _regionManager;
        private readonly IMenuService _menuService;
        private readonly GlobalInfo _globalInfo;

        public ObservableCollection<TreeMenuModel> Menus { get; set; } = new ObservableCollection<TreeMenuModel>();
        private IList<SysMenuDto> allMenus { get; set; }

        public DelegateCommand<TreeMenuModel> OpenViewCommand { get; set; }

        public TreeMenuViewModel(IMenuService menuService, IRegionManager regionManager, GlobalInfo globalInfo)
        {
            _menuService = menuService;
            _regionManager = regionManager;
            _globalInfo = globalInfo;

            OpenViewCommand = new DelegateCommand<TreeMenuModel>(menu =>
            {
                if ((menu.Children == null || !menu.Children.Any()) && !string.IsNullOrEmpty(menu.ViewName))
                    _regionManager.RequestNavigate("MainViewRegion", menu.ViewName);
                else
                    menu.IsExpanded = !menu.IsExpanded;
            });

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
                    var menu = new TreeMenuModel()
                    {
                        MenuIcon = item.MenuIcon,
                        MenuName = item.MenuName,
                        ViewName = item.ViewName,
                        Children = new ObservableCollection<TreeMenuModel>()
                    };
                    menus.Add(menu);
                    FillMenus(menu.Children, item.Id);
                }
            }
        }
    }
}
