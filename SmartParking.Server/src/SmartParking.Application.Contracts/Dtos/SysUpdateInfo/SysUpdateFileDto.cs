using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SmartParking.Dtos.SysUpdateInfo
{
    public class SysUpdateFileDto : EntityDto<Guid>
    {
        public string FileName { get; set; }

        public string FileMD5 { get; set; }

        public string FilePath { get; set; }

        public int Length { get; set; }
    }
}
