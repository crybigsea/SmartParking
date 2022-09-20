using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SmartParking.Dtos.SysUserInfo
{
    public class LoginOutputDto : EntityDto<Guid>
    {
        public string UserName { get; set; }

        public string UserIcon { get; set; }

        public string RealName { get; set; }

        public string Token { get; set; }
    }
}
