using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class CertificateInfo
    {
        [XmlAttribute]
        public string LongName { get; set; }

        [XmlAttribute]
        public string ShortName { get; set; }

        [XmlAttribute]
        public CertUsageType UsageType { get; set; }

        [XmlAttribute]
        public string ThumbPrint { get; set; }
    }
}
