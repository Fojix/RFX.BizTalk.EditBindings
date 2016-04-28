using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class Transform
    {
        [XmlAttribute]
        public string FullName { get; set; }
        [XmlAttribute]
        public string AssemblyQualifiedName { get; set; }

    }
}
