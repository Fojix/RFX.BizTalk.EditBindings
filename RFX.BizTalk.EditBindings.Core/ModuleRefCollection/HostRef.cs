using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class HostRef
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string NTGroupName { get; set; }
        [XmlAttribute]
        public int Type { get; set; }
        [XmlAttribute]
        public bool Trusted { get; set; }

    }
}
