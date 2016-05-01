using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using RFX.BizTalk.EditBindings.Core;

namespace RFX.BizTalk.EditBindings.Logic
{
    public class BindingLogic
    {
        public BindingFile OriginalBindingFile { get; set; }
        public BindingFile EditableBindingFile { get; set; }

        public void OpenBindingFile(string path)
        {
            // Set both the original binding file and the editable bindingfile
            // The original bindingfile is there to be able to reset any changes made
            OriginalBindingFile = new BindingFile();
            EditableBindingFile = new BindingFile();

            XmlSerializer ser = new XmlSerializer(typeof(BindingInfo));

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                OriginalBindingFile.BindingInfo = (BindingInfo)ser.Deserialize(fs);
                OriginalBindingFile.FileName = path;
                EditableBindingFile = OriginalBindingFile;
            }
            
        }

        public void SaveBindingFile(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(BindingInfo));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                ser.Serialize(sw, EditableBindingFile.BindingInfo);
                fs.Flush();
            }
        
        }

        public void SortSendPortsAz()
        {
            EditableBindingFile.BindingInfo.SendPortCollection =
                EditableBindingFile.BindingInfo.SendPortCollection.OrderBy(port => port.Name).ToList();
        }

        public void SortSendPortsZa()
        {
            EditableBindingFile.BindingInfo.SendPortCollection =
                EditableBindingFile.BindingInfo.SendPortCollection.OrderByDescending(port => port.Name).ToList();
        }



        public static string PrintXml(string xml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            var sb = new StringBuilder();
            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                xmlDoc.Save(writer);
            }
            return sb.ToString();
        }
    }
}
