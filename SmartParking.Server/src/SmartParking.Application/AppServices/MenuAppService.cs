using Microsoft.AspNetCore.Authorization;
using SmartParking.Dtos.SysMenu;
using SmartParking.Entitys;
using SmartParking.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SmartParking.AppServices
{
    //[Authorize]
    public class MenuAppService : CrudAppService<SysMenu, SysMenuDto, Guid>, IMenuAppService
    {
        public MenuAppService(IRepository<SysMenu, Guid> repository) : base(repository)
        {
        }
    }
}
