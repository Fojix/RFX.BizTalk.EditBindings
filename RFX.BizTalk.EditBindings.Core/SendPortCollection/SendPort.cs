using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class SendPort
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsStatic { get; set; }

        [XmlAttribute]
        public bool IsTwoWay { get; set; }

        private BindingType _bindingOption;
        [XmlAttribute]
        public int BindingOption {
            get { return (int) _bindingOption; }
            set { _bindingOption = (BindingType) value; }
        }

        [XmlElement(IsNullable = true)]
        public string Description { get; set; }

        [XmlElement]
        public PipelineRef TransmitPipeline { get; set; }

        [XmlElement]
        public string SendPipelineData { get; set; }

        [XmlElement]
        public TransportInfo PrimaryTransport { get; set; }

        [XmlElement]
        public TransportInfo SecondaryTransport { get; set; }

        [XmlElement]
        public CertificateInfo EncryptionCert { get; set; }

        [XmlElement]
        public PipelineRef ReceivePipeline { get; set; }

        [XmlElement(IsNullable = true)]
        public string ReceivePipelineData { get; set; }

        [XmlElement]
        public int Tracking { get; set; }

        [XmlElement]
        public string Filter { get; set; }

        [XmlArray]
        public List<Transform> Transforms { get; set; }

        [XmlArray]
        public List<Transform> InboundTransforms { get; set; }

        [XmlElement]
        public bool OrderedDelivery { get; set; }

        [XmlElement]
        public int Priority { get; set; }

        [XmlElement]
        public bool StopSendingOnFailure { get; set; }

        [XmlElement]
        public bool RouteFailedMessage { get; set; }

        [XmlElement]
        public string ApplicationName { get; set; }

        public bool ShouldSerializeInboundTransforms()
        {
            return (InboundTransforms.Count > 0);
        }
    }
}
