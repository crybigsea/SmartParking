using SmartParking.Dtos.SysUserInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SmartParking.IAppServices
{
    public interface ILoginAppService
    {
        Task<LoginOutputDto> Post(LoginDto input);
        Task<LoginOutputDto> Get();
    }
}
