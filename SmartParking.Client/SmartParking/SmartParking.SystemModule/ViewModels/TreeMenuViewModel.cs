﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SmartParking.Client;
using SmartParking.Client.Dtos.SysMenu;
using SmartParking.Common;
using SmartParking.SystemModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SmartParking.SystemModule.ViewModels
{
    public class TreeMenuViewModel
    {
        private readonly IMenuService _menuService;
        private readonly GlobalInfo _globalInfo;

        public ObservableCollection<TreeMenuModel> Menus { get; set; } = new ObservableCollection<TreeMenuModel>();
        private IList<SysMenuDto> allMenus { get; set; }
        private IRegionManager _regionManager { get; set; }

        public TreeMenuViewModel(IMenuService menuService, IRegionManager regionManager, GlobalInfo globalInfo)
        {
            _menuService = menuService;
            _regionManager = regionManager;
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
                        Children = new ObservableCollection<TreeMenuModel>()
                    };
                    menus.Add(menu);
                    FillMenus(menu.Children, item.Id);
                }
            }
        }
    }
}
