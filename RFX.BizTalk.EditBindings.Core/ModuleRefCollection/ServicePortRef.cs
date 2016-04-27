using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    [XmlRoot]
    public class ServicePortRef
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Modifier { get; set; }
        [XmlAttribute]
        public int BindingOption { get; set; }

        [XmlElement]
        public SendPortRef SendPortRef { get; set; }
        [XmlElement]
        public DistributionListRef DistributionListRef { get; set; }
        [XmlElement]
        public ReceivePortRef ReceivePortRef { get; set; }
    }
}
