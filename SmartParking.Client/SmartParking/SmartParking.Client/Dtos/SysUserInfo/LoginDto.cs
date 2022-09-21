using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartParking.Client.Dtos.SysUserInfo
{
    public class LoginDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
