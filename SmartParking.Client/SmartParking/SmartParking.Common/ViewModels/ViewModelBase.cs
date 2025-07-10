using System.Windows.Input;

namespace SmartParking.Common.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;

        public string PageTitle { get; set; }

        public string NavUri { get; set; }

        public string AddButtonText { get; set; } = "新增";


        private string keyword;
        public string Keyword
        {
            get { return keyword; }
            set { SetProperty(ref keyword, value); }
        }


        public ICommand RefreshCommand { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ViewModelBase(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
            RefreshCommand = new DelegateCommand(Refresh);
            AddCommand = new DelegateCommand(Add);
            CloseCommand = new DelegateCommand(Close);
        }

        public virtual void Refresh()
        {
        }

        public virtual void Add()
        {
        }

        public virtual void Close()
        {
            var registrationObj = _unityContainer.Registrations.Where(r => r.Name == NavUri).FirstOrDefault();
            var viewType = registrationObj.MappedToType.Name;

            var region = _regionManager.Regions["MainViewRegion"];
            var view = region.Views.FirstOrDefault(v => v.GetType().Name == viewType);
            if (view != null)
                region.Remove(view);
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavUri = navigationContext.Uri.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
