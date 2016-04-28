using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class ReceiveHandlerRef
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool HostTrusted { get; set; }

        [XmlElement]
        public ProtocolType TransportType { get; set; }
    }
}
