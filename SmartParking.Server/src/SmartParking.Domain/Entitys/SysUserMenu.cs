using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SmartParking.Entitys
{
    public class SysUserMenu : FullAuditedEntity<Guid>
    {
        public Guid UserId { get; set; }

        public Guid MenuId { get; set; }
    }
}
