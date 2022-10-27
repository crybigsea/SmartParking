using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SmartParking.Entitys
{
    public class SysUpdateFile : FullAuditedEntity<Guid>
    {
        [MaxLength(255)]
        public string FileName { get; set; }

        [MaxLength(255)]
        public string FileMD5 { get; set; }

        [MaxLength(255)]
        public string FilePath { get; set; }

        public int State { get; set; }

        public int Length { get; set; }
    }
}
