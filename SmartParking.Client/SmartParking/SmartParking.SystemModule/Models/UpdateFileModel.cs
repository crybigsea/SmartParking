using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.SystemModule.Models
{
    public class UpdateFileModel : BindableBase
    {
        public Guid Id { get; set; }
        public int Index { get; set; }
        public string FileName { get; set; }

        public string FileMD5 { get; set; }

        public string FilePath { get; set; }

        public int Length { get; set; }
    }
}
