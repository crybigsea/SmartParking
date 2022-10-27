using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Dtos.SysUpdateInfo
{
    public class SysUpdateFileDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }

        public string FileMD5 { get; set; }

        public string FilePath { get; set; }

        public int Length { get; set; }
    }
}
