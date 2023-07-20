using Refit;
using SmartParking.Client.Dtos;
using SmartParking.Client.Dtos.SysMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client
{
    public interface IMenuService
    {
        [Get("/menu")]
        Task<ApiListResult<SysMenuDto>> GetAllMenus([Header("Authorization")] string token);
    }
}
