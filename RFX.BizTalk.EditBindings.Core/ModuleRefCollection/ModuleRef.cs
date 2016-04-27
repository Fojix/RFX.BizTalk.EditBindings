using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class ModuleRef
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Version { get; set; }
        [XmlAttribute]
        public string Culture { get; set; }
        [XmlAttribute]
        public string PublicKeyToken { get; set; }
        [XmlAttribute]
        public string FullName { get; set; }


        [XmlArray]
        public List<Service> Services { get; set; }

        [XmlArray]
        public List<Schema> TrackedSchemas { get; set; }
    }
}
