using Prism.Commands;
using Prism.Mvvm;
using Refit;
using SmartParking.Client;
using SmartParking.Client.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
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

        private string errorMesage = "";

        public string ErrorMessage
        {
            get { return errorMesage; }
            set { SetProperty(ref errorMesage, value); }
        }


        public ICommand LoginCommand { get; set; }
        public LoginWindowViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            LoginCommand = new DelegateCommand<object>(async obj =>
            {
                try
                {
                    if (string.IsNullOrEmpty(UserName))
                    {
                        this.ErrorMessage = "请输入用户名";
                        return;
                    }
                    if (string.IsNullOrEmpty(Password))
                    {
                        this.ErrorMessage = "请输入密码";
                        return;
                    }
                    var loginResult = await _loginService.Post(new Client.Dtos.SysUserInfo.LoginDto
                    {
                        UserName = UserName,
                        Password = Password
                    });
                    (obj as Window).DialogResult = true;
                }
                catch (ApiException apiEx)
                {
                    string content = apiEx.Content;
                    if (string.IsNullOrEmpty(content))
                        throw apiEx;
                    ApiResult result = JsonSerializer.Deserialize<ApiResult>(content);
                    ErrorMessage = result.error.message;
                }
                catch (Exception ex)
                {

                }
            });
        }
    }
}
