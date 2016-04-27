using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class EnlistedParty
    {
        [XmlElement]
        public string Name { get; set; }
        [XmlArray]
        public List<EnlistedPartyMapping> Mappings { get; set; }
    }
}
