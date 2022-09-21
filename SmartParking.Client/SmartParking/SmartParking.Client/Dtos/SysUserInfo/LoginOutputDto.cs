using System;
using System.Collections.Generic;
using System.Text;

namespace SmartParking.Dtos.SysUserInfo
{
    public class LoginOutputDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string UserIcon { get; set; }

        public string RealName { get; set; }

        public string Token { get; set; }
    }
}
