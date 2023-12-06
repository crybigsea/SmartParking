using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workflow.Application.Contracts.Models
{
    public class ComboSelectListItem
    {
        public string? Value { get; set; }
        public string? Text { get; set; }
        public bool Disabled { get; set; }
    }
}
