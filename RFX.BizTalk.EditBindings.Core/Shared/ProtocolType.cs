using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class ProtocolType
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int Capabilities
        {
            get { return (int) _capabilities; }
            set { _capabilities = (CapabilityType) value; }
        }

        [XmlAttribute]
        public string ConfigurationClsid { get; set; }

        [XmlIgnore] private CapabilityType _capabilities;
    }
}
