using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.DashboardModule.Models
{
    public class BoardModel
    {
        public string Icon { get; set; }
        public string Header { get; set; }
        public double Value { get; set; }
        public string Flag { get; set; }
        public double GrowingRate { get; set; }
        public string Color { get; set; }
    }
}
