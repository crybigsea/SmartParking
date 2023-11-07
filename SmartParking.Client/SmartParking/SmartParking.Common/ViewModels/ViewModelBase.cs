﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;
using Unity;

namespace SmartParking.Common.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        private readonly IUnityContainer _unityContainer;
        private readonly IRegionManager _regionManager;

        public string PageTitle { get; set; }

        public string NavUri { get; set; }


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
            PageTitle = "文件上传";
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
