using Prism.Commands;
using Prism.Mvvm;
using Refit;
using SmartParking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.ViewModels
{
    public class LoginWindowViewModel : BindableBase
    {
        private readonly ILoginService _loginService;

        private string userName = "";

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

        public ICommand LoginCommand { get; set; }
        public LoginWindowViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            LoginCommand = new DelegateCommand(async () =>
            {
                var obj = await _loginService.Post(new Client.Dtos.SysUserInfo.LoginDto
                {
                    UserName = "admin",
                    Password = "123456"
                });
            });
        }
    }
}
