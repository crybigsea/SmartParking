using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;

namespace SmartParking.SystemModule.Models
{
    public class TreeMenuModel : BindableBase
    {
        public Guid Id { get; set; }

        public string MenuName { get; set; }

        public string ViewName { get; set; }

        public string MenuIcon { get; set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }

        public Guid? ParentId { get; set; }

        public bool IsLastChild { get; set; }

        public ObservableCollection<TreeMenuModel> Children { get; set; }
    }
}
