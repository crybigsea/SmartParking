using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SmartParking.Dtos.SysUpdateInfo
{
    public class SysUpdateFilePagedResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
