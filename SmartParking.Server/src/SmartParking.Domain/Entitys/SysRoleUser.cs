using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace SmartParking.Entitys
{
    public class SysRoleUser : FullAuditedEntity<Guid>
    {
        public Guid RoleId { get; set; }

        public Guid UserId { get; set; }
    }
}
