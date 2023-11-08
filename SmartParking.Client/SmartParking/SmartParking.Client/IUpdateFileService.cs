
using Refit;
using SmartParking.Client.Dtos.SysMenu;
using SmartParking.Client.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartParking.Client.Dtos.SysUpdateInfo;

namespace SmartParking.Client
{
    public interface IUpdateFileService
    {
        [Get("/updateFile")]
        Task<ApiListResult<SysUpdateFileDto>> GetPagedFiles([Header("Authorization")] string token, SysUpdateFilePagedResultRequestDto input);
    }
}
