using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Dtos
{
    public class ApiResult
    {
        public Error error { get; set; }
    }

    public class Error
    {
        public object code { get; set; }
        public string message { get; set; }
        public object details { get; set; }
        public Data data { get; set; }
        public object validationErrors { get; set; }
    }

    public class Data
    {
    }
}
