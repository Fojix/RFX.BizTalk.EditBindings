﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class ReceivePort
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsTwoWay { get; set; }

        private BindingType _bindingOption;
        [XmlAttribute]
        public int BindingOption
        {
            get { return (int)_bindingOption; }
            set { _bindingOption = (BindingType)value; }
        }

        [XmlElement(IsNullable = true)]
        public string Description { get; set; }

        [XmlArray]
        public List<ReceiveLocation> ReceiveLocations { get; set; }

        [XmlElement]
        public PipelineRef TransmitPipeline { get; set; }

        [XmlElement(IsNullable = true)]
        public string SendPipelineData { get; set; }

        [XmlElement]
        public int Authentication { get; set; }

        [XmlElement]
        public int Tracking { get; set; }

        [XmlArray]
        public List<Transform> Transforms { get; set; }

        [XmlArray]
        public List<Transform> OutboundTransforms { get; set; }

        [XmlElement]
        public bool RouteFailedMessage { get; set; }

        [XmlElement]
        public string ApplicationName { get; set; }


        public bool ShouldSerializeOutboundTransforms()
        {
            return (OutboundTransforms.Count > 0);
        }
    }
}
