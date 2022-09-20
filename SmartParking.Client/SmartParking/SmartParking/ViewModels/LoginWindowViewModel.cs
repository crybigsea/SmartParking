using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }

        private string password = "";

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }


    }
}
