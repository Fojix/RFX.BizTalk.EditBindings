using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class RoleRef
    {
        [XmlAttribute]
        public string Role { get; set; }
        [XmlAttribute]
        public string RoleLinkTypeName { get; set; }
        [XmlAttribute]
        public RoleType RoleType { get; set; }

        [XmlArray]
        public List<EnlistedParty> EnlistedParties { get; set; }

    }
}
