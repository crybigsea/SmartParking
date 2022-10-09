using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SmartParking.Dtos.SysMenu
{
    public class SysMenuDto : EntityDto<Guid>
    {
        public string MenuName { get; set; }

        public string ViewName { get; set; }

        public Guid? ParentId { get; set; }

        public string MenuIcon { get; set; }

        public int Sort { get; set; }
    }
}
