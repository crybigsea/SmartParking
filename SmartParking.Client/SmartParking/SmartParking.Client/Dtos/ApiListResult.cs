using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Dtos
{
    public class ApiListResult<T>
    {
        public int totalCount { get; set; }

        public IList<T> items { get; set; }
    }
}
