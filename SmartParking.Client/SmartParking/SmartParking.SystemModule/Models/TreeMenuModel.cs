using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.SystemModule.Models
{
    public class TreeMenuModel : BindableBase
    {
        public string MenuName { get; set; }

        public string ViewName { get; set; }

        public string MenuIcon { get; set; }

        public ObservableCollection<TreeMenuModel> Children { get; set; }

        public ICommand OpenViewCommand
        {
            get
            {
                return new DelegateCommand<TreeMenuModel>(menu =>
                {
                    if ((menu.Children == null || !menu.Children.Any()) && !string.IsNullOrEmpty(menu.ViewName))
                        _regionManager.RequestNavigate("MainViewRegion", menu.ViewName);
                });
            }
        }
        private IRegionManager _regionManager;
        public TreeMenuModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
    }
}
