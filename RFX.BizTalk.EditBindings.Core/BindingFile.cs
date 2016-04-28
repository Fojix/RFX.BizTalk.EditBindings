using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFX.BizTalk.EditBindings.Core
{
    public class BindingFile
    {
        public string FileName { get; set; }
        public string ApplicationName { get; set; }
        public BindingInfo BindingInfo { get; set; }
    }
}
