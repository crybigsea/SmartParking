using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SmartParking.SystemModule.Models
{
    public class TreeMenuModel : BindableBase
    {
        public string MenuName { get; set; }

        public string ViewName { get; set; }

        public string MenuIcon { get; set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }


        public ObservableCollection<TreeMenuModel> Children { get; set; }

        public ICommand OpenViewCommand
        {
            get
            {
                return new DelegateCommand<TreeMenuModel>(menu =>
                {
                    if ((menu.Children == null || !menu.Children.Any()) && !string.IsNullOrEmpty(menu.ViewName))
                        _regionManager.RequestNavigate("MainViewRegion", menu.ViewName);
                    else
                        menu.IsExpanded = !menu.IsExpanded;
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
