using Prism.Dialogs;
using Prism.Navigation.Regions;
using SmartParking.Client;
using SmartParking.Common;
using SmartParking.SystemModule.Models;

namespace SmartParking.SystemModule.ViewModels
{
    public class MenuOperateViewModel : IDialogAware
    {
        private readonly IMenuService _menuService;
        private readonly GlobalInfo _globalInfo;
        private readonly RegionManager _regionManager;

        public string Title { get; set; }

        public DialogCloseListener RequestClose { get; }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            TreeMenuModel model = parameters.GetValue<TreeMenuModel>("mdoel");
            if (model == null)
            {
                Title = "新增菜单";
            }
            else
            {
                Title = "编辑菜单";

                var menuInfo = _menuService.GetEntity($"Bearer {_globalInfo.LoginUserInfo?.Token}", model.Id).GetAwaiter().GetResult();
                menuModel.Id = menuInfo.Id;
                menuModel.MenuName = menuInfo.MenuName;
                menuModel.MenuIcon = menuInfo.MenuIcon;
                menuModel.ViewName = menuInfo.ViewName;
                menuModel.ParentId = menuInfo.ParentId;
            }
        }

        public MenuOperateViewModel(IMenuService menuService, GlobalInfo globalInfo, RegionManager regionManager)
        {
            _menuService = menuService;
            _globalInfo = globalInfo;
            _regionManager = regionManager;

        }

        public TreeMenuModel menuModel { get; set; } = new TreeMenuModel();
    }
}
