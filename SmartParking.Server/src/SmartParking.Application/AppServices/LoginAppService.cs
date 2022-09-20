using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using SmartParking.Dtos.SysUserInfo;
using SmartParking.Entitys;
using SmartParking.IAppServices;
using System.Linq.Dynamic.Core.Tokenizer;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Validation;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SmartParking.AppServices
{
    public class LoginAppService : SmartParkingAppService, ILoginAppService, IValidationEnabled
    {
        private readonly IRepository<SysUserInfo> _userInfoRepository;
        private readonly IConfiguration _configuration;

        public LoginAppService(IRepository<SysUserInfo> userInfoRepository, IConfiguration configuration)
        {
            _userInfoRepository = userInfoRepository;
            _configuration = configuration;
        }

        public async Task<LoginOutputDto> Post(LoginDto input)
        {
            var userInfo = await _userInfoRepository.FirstOrDefaultAsync(u => u.UserName == input.UserName && u.Password == input.Password);
            if (userInfo == null)
                throw new UserFriendlyException("用户名或密码错误");
            if (userInfo.State != 1)
                throw new UserFriendlyException("用户被禁用");
            LoginOutputDto outputDto = ObjectMapper.Map<SysUserInfo, LoginOutputDto>(userInfo);

            var claims = new[] {
                new Claim(ClaimTypes.Name, outputDto.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:SecurityKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                _configuration["JwtAuth:Issuer"],
                _configuration["JwtAuth:Audience"],
                claims,
            expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            outputDto.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return outputDto;
        }

        [Authorize]
        public Task<LoginOutputDto> Get()
        {
            throw new UserFriendlyException("用户名或密码错误");
        }
    }
}
