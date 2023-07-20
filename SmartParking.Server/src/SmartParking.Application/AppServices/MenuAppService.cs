using Microsoft.AspNetCore.Authorization;
using SmartParking.Dtos.SysMenu;
using SmartParking.Entitys;
using SmartParking.IAppServices;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SmartParking.AppServices
{
    [Authorize]
    public class MenuAppService : CrudAppService<SysMenu, SysMenuDto, Guid>, IMenuAppService
    {
        public MenuAppService(IRepository<SysMenu, Guid> repository) : base(repository)
        {
        }
    }
}
