using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class Schema
    {
        [XmlAttribute]
        public string FullName { get; set; }
        [XmlAttribute]
        public string RootName { get; set; }
        [XmlAttribute]
        public string AssemblyQualifiedName { get; set; }
        [XmlAttribute]
        public bool AlwaysTrackAllProperties { get; set; }
        [XmlAttribute]
        public string Description { get; set; }

        [XmlArray]
        public List<string> TrackedPropertyNames { get; set; }
    }
}
