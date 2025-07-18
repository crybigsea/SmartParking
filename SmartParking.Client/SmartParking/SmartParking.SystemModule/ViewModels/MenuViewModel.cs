using Prism.Commands;
using Prism.Dialogs;
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
using System.Windows.Input;
using Unity;

namespace SmartParking.SystemModule.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;
        private readonly IDialogService _dialogService;
        private readonly IMenuService _menuService;
        private readonly GlobalInfo _globalInfo;

        public ObservableCollection<TreeMenuModel> Menus { get; set; } = new ObservableCollection<TreeMenuModel>();

        public ICommand EditCommand { get; set; }
        
        private IList<SysMenuDto> allMenus { get; set; }

        public MenuViewModel(
            IUnityContainer unityContainer,
            IRegionManager regionManager,
            IDialogService dialogService,
            IMenuService menuService,
            GlobalInfo globalInfo)
            : base(unityContainer, regionManager)
        {
            PageTitle = "菜单管理";
            _unityContainer = unityContainer;
            _regionManager = regionManager;
            _dialogService = dialogService;
            _menuService = menuService;
            _globalInfo = globalInfo;

            EditCommand = new DelegateCommand<TreeMenuModel>(menu =>
            {
                DialogParameters param = new DialogParameters();
                param.Add("mdoel", menu);
                _dialogService.ShowDialog("MenuOperateView", param, result =>
                {
                    Refresh();
                });
            });

            Refresh();
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
                        Id = item.Id,
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

        public override void Refresh()
        {
            Menus.Clear();
            allMenus = _menuService.GetAllMenus($"Bearer {_globalInfo.LoginUserInfo?.Token}").GetAwaiter().GetResult().items;
            FillMenus(Menus, null);
        }

        public override void Add()
        {
            _dialogService.ShowDialog("MenuOperateView");
        }
    }
}
