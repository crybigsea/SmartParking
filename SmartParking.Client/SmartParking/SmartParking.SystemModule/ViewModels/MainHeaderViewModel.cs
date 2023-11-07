using Prism.Mvvm;
using SmartParking.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.SystemModule.ViewModels
{
    public class MainHeaderViewModel : BindableBase
    {
        private string _currentUserName;
        public string CurrentUserName
        {
            get { return _currentUserName; }
            set { SetProperty(ref _currentUserName, value); }
        }

        private string _userAvatar;
        public string UserAvatar
        {
            get { return _userAvatar; }
            set { SetProperty(ref _userAvatar, value); }
        }

        public MainHeaderViewModel(GlobalInfo globalInfo)
        {
            CurrentUserName = globalInfo.LoginUserInfo?.UserName;
            UserAvatar = "http://localhost:4439" + globalInfo.LoginUserInfo?.UserIcon;
        }
    }
}
