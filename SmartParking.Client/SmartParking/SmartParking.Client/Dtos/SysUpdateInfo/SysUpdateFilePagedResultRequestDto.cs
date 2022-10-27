using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Dtos.SysUpdateInfo
{
    public class SysUpdateFilePagedResultRequestDto
    {
        public string Keyword { get; set; }

        public int SkipCount { get; set; }

        public int MaxResultCount { get; set; }
    }
}
