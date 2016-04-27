using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class EnlistedPartyMapping
    {
        [XmlElement]
        public string PortTypeName { get; set; }
        [XmlElement]
        public string OperationName { get; set; }
        [XmlElement]
        public SendPortRef SendPortRef { get; set; }
    }
}
