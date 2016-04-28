using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RFX.BizTalk.EditBindings.Core
{
    public class PipelineRef
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string FullyQualifiedName { get; set; }

        [XmlIgnore]
        private PipelineType _type;
        [XmlAttribute]
        public int Type {
            get { return (int) _type;  }
            set { _type = (PipelineType)value;  } 
        }

        [XmlIgnore]
        private List<PipelineTrackingType> _trackingOptions;
        [XmlAttribute]
        public string TrackingOption { get; set; }

        [XmlAttribute]
        public string Description { get; set; }


        /// <summary>
        /// Set the tracking options from the string. Converts the string to a collection of options.
        /// </summary>
        /// <param name="trackingOptionsString"></param>
        private void SetTrackingOptions(string trackingOptionsString)
        {
            _trackingOptions = new List<PipelineTrackingType>();
            string[] trackingOptions = trackingOptionsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var s in trackingOptions)
            {
                _trackingOptions.Add((PipelineTrackingType)Enum.Parse(typeof(PipelineTrackingType), s));
            }
        }

        /// <summary>
        /// Gets the tracking options, concatinates it to string
        /// </summary>
        /// <returns></returns>
        private string GetTrackingOptions()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var trackingOption in _trackingOptions)
            {
                sb.Append(trackingOption.ToString());
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd(' ');
        }
    }
}
