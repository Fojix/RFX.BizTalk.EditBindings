using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class DistributionList
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray]
        public List<SendPortRef> SendPorts { get; set; }

        [XmlElement]
        public string Filter { get; set; }

        [XmlElement]
        public string ApplicationName { get; set; }

        [XmlElement]
        public string Description { get; set; }

    }
}
