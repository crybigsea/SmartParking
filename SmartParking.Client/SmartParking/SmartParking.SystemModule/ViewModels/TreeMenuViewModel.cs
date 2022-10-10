using Prism.Regions;
using SmartParking.Client;
using SmartParking.Client.Dtos.SysMenu;
using SmartParking.SystemModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SmartParking.SystemModule.ViewModels
{
    public class TreeMenuViewModel
    {
        private readonly IMenuService _menuService;

        public ObservableCollection<TreeMenuModel> Menus { get; set; } = new ObservableCollection<TreeMenuModel>();
        private IList<SysMenuDto> allMenus { get; set; }
        private IRegionManager _regionManager { get; set; }

        public TreeMenuViewModel(IMenuService menuService, IRegionManager regionManager)
        {
            _menuService = menuService;
            _regionManager = regionManager;

            allMenus = _menuService.GetAllMenus().GetAwaiter().GetResult().items;
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
