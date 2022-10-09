using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.SystemModule.Models
{
    public class TreeMenuModel : BindableBase
    {
        public string MenuName { get; set; }

        public string ViewName { get; set; }

        public string MenuIcon { get; set; }

        public ObservableCollection<TreeMenuModel> Children { get; set; }
    }
}
