using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Dtos.SysMenu
{
    public class SysMenuDto
    {
        public Guid Id { get; set; }

        public string MenuName { get; set; }

        public string ViewName { get; set; }

        public Guid? ParentId { get; set; }

        public string MenuIcon { get; set; }

        public int Sort { get; set; }
    }
}
