using Refit;
using SmartParking.Client.Dtos.SysUserInfo;
using SmartParking.Dtos.SysUserInfo;

namespace SmartParking.Client
{
    public interface ILoginService
    {
        [Post("/login")]
        new Task<LoginOutputDto> Post([Body] LoginDto input);
    }
}