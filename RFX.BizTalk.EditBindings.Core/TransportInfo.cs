using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class TransportInfo
    {
        [XmlElement]
        public string Address { get; set; }

        [XmlElement]
        public ProtocolType TransportType { get; set; }

        [XmlElement]
        public string TransportTypeData { get; set; }

        [XmlElement]
        public int RetryCount { get; set; }

        [XmlElement]
        public int RetryInterval { get; set; }

        [XmlElement]
        public bool ServiceWindowEnabled { get; set; }

        [XmlElement]
        public DateTime FromTime { get; set; }

        [XmlElement]
        public DateTime ToTime { get; set; }

        [XmlElement]
        public bool Primary { get; set; }

        [XmlElement]
        public bool OrderedDelivery { get; set; }

        [XmlElement]
        public int DeliveryNotification { get; set; }

        [XmlElement]
        public SendHandlerRef SendHandler { get; set; }
    }
}
