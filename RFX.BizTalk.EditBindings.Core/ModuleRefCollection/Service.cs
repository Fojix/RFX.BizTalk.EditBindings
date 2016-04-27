using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class Service
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public ServiceRefState State { get; set; }
        [XmlAttribute]
        public string TrackingOption {
            get { return GetTrackingOptions(); }
            set { SetTrackingOptions(value); }
        }
        [XmlAttribute]
        public string Description { get; set; }

        [XmlArray]
        public List<ServicePortRef> Ports { get; set; }
        [XmlArray]
        public List<RoleRef> Roles { get; set; }
        [XmlElement]
        public HostRef Host { get; set; }

        [XmlIgnore]
        private List<OrchestrationTrackingType> OrchestrationTrackingTypesCollection { get; set; }

        /// <summary>
        /// Set the tracking options from the string. Converts the string to a collection of options.
        /// </summary>
        /// <param name="trackingOptionsString"></param>
        private void SetTrackingOptions(string trackingOptionsString)
        {
            OrchestrationTrackingTypesCollection = new List<OrchestrationTrackingType>();
            string[] trackingOptions = trackingOptionsString.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in trackingOptions)
            {
                OrchestrationTrackingTypesCollection.Add((OrchestrationTrackingType)Enum.Parse(typeof(OrchestrationTrackingType), s));
            }
        }

        /// <summary>
        /// Gets the tracking options, concatinates it to string
        /// </summary>
        /// <returns></returns>
        private string GetTrackingOptions()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var trackingOption in OrchestrationTrackingTypesCollection)
            {
                sb.Append(trackingOption.ToString());
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd(' ');
        }
    }
}
