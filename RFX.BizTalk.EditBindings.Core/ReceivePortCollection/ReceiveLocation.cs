using System;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class ReceiveLocation
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement(IsNullable = true)]
        public string Description { get; set; }

        [XmlElement]
        public string Address { get; set; }

        [XmlElement]
        public string PublicAddress { get; set; }

        [XmlElement]
        public bool Primary { get; set; }

        [XmlElement]
        public bool ReceiveLocationServiceWindowEnabled { get; set; }

        [XmlElement]
        public DateTime ReceiveLocationFromTime { get; set; }

        [XmlElement]
        public DateTime ReceiveLocationToTime { get; set; }

        [XmlElement]
        public bool ReceiveLocationStartDateEnabled { get; set; }

        [XmlElement]
        public DateTime ReceiveLocationStartDate { get; set; }

        [XmlElement]
        public bool ReceiveLocationEndDateEnabled { get; set; }

        [XmlElement]
        public DateTime ReceiveLocationEndDate { get; set; }

        [XmlElement]
        public ProtocolType ReceiveLocationTransportType { get; set; }

        [XmlElement]
        public string ReceiveLocationTransportTypeData { get; set; }

        [XmlElement]
        public PipelineRef ReceivePipeline { get; set; }

        [XmlElement]
        public string ReceivePipelineData { get; set; }

        [XmlElement(IsNullable = true)]
        public PipelineRef SendPipeline { get; set; }

        [XmlElement(IsNullable = true)]
        public string SendPipelineData { get; set; }

        [XmlElement]
        public CertificateInfo EncryptionCert { get; set; }

        [XmlElement]
        public bool Enable { get; set; }

        [XmlElement]
        public ReceiveHandlerRef ReceiveHandler { get; set; }

    }
}
