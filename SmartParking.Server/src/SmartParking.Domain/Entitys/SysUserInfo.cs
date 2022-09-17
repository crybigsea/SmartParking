using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace SmartParking.Entitys
{
    public class SysUserInfo: FullAuditedEntity<Guid>
    {
        [MaxLength(20)]
        public string UserName { get; set; }

        [MaxLength(200)]

        public string Password { get; set; }

        [MaxLength(200)]

        public string UserIcon { get; set; }

        [MaxLength(20)]

        public string RealName { get; set; }

        public int? Age { get; set; }

        public int State { get; set; }
    }
}
