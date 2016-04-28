using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{

    [XmlRoot(Namespace = "")]
    public class BindingInfo
    {
        [XmlAttribute]
        public string Assembly { get; set; }
        [XmlAttribute]
        public string Version { get; set; }
        [XmlAttribute]
        public BindingStatus BindingStatus { get; set; }
        [XmlAttribute]
        public int BoundEndpoints { get; set; }
        [XmlAttribute]
        public int TotalEndpoints { get; set; }

        [XmlElement]
        public string Description { get; set; }
        [XmlElement]
        public DateTime Timestamp { get; set; }

        [XmlArray(IsNullable = true)]
        public List<ModuleRef> ModuleRefCollection { get; set; }
        [XmlArray(IsNullable = true)]
        public List<SendPort> SendPortCollection { get; set; }
        [XmlArray(IsNullable = true)]
        public List<DistributionList> DistributionListCollection { get; set; }
        [XmlArray(IsNullable = true)]
        public List<ReceivePort> ReceivePortCollection { get; set; }
        
        // TODO: Add Party and EDI part. Very much work, sprint 2 ;)
        //[XmlArray(IsNullable = true)]
        //public List<Party> PartyCollection { get; set; }


        public BindingInfo()
        {
            Assembly = "Microsoft.BizTalk.Deployment, Version=3.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";
            Version = "3.5.1.0";

            BindingStatus = BindingStatus.Unknown;

            BoundEndpoints = 0;
            TotalEndpoints = 0;

            Timestamp = DateTime.Now;
        }
    }
}
