using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SmartParking.Entitys
{
    public class SysMenu : FullAuditedEntity<Guid>
    {
        [MaxLength(20)]
        public string MenuName { get; set; }

        [MaxLength(200)]
        public string ViewName { get; set; }

        public Guid? ParentId { get; set; }

        [MaxLength(4)]
        public string MenuIcon { get; set; }

        public int Sort { get; set; }

        public int State { get; set; }
    }
}
