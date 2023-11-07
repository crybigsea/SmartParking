using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SmartParking.Entitys
{
    public class SysRole : FullAuditedEntity<Guid>
    {
        [MaxLength(20)]
        public string RoleName { get; set; }

        public int Sort { get; set; }

        public int State { get; set; }
    }
}
