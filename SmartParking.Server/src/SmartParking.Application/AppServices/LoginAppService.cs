using SmartParking.Dtos.SysUserInfo;
using SmartParking.Entitys;
using SmartParking.IAppServices;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;

namespace SmartParking.AppServices
{
    public class LoginAppService : SmartParkingAppService, ILoginAppService, IValidationEnabled
    {
        private readonly IRepository<SysUserInfo> _userInfoRepository;

        public LoginAppService(IRepository<SysUserInfo> userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public async Task<LoginOutputDto> Post(LoginDto input)
        {
            var userInfo = await _userInfoRepository.FirstOrDefaultAsync(u => u.UserName == input.UserName && u.Password == input.Password);
            if (userInfo == null)
                throw new UserFriendlyException("用户名或密码错误");
            if (userInfo.State != 1)
                throw new UserFriendlyException("用户被禁用");
            LoginOutputDto outputDto = ObjectMapper.Map<SysUserInfo, LoginOutputDto>(userInfo);
            return outputDto;
        }

        public Task<LoginOutputDto> Get()
        {
            throw new UserFriendlyException("用户名或密码错误");
        }
    }
}
