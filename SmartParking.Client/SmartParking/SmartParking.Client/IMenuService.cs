using Refit;
using SmartParking.Client.Dtos;
using SmartParking.Client.Dtos.SysMenu;

namespace SmartParking.Client
{
    public interface IMenuService
    {
        [Get("/menu")]
        Task<ApiListResult<SysMenuDto>> GetAllMenus([Header("Authorization")] string token);

        [Get("/menu/{id}")]
        Task<SysMenuDto> GetEntity([Header("Authorization")] string token, Guid id);
    }
}
