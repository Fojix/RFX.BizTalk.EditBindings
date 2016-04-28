using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using RFX.BizTalk.EditBindings.Core;


namespace RFX.BizTalk.EditBindings.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(BindingInfo));

            using (
                FileStream fs = new FileStream(@"C:\Projects\GIT\RFX.BizTalk.EditBindings\TempBindings.xml",
                    FileMode.Open))
            {
                BindingInfo bi = (BindingInfo) ser.Deserialize(fs);
                
                using (
                    FileStream fsOut = new FileStream(
                        @"C:\Projects\GIT\RFX.BizTalk.EditBindings\TempBindings - OUT - " + DateTime.Now.ToString("yyMMdd_HHmmss") + ".xml", FileMode.CreateNew))
                {
                    StreamWriter sw = new StreamWriter(fsOut, Encoding.UTF8);
                    ser.Serialize(sw, bi);
                    fsOut.Flush();
                }

                
            }
        }
    }
}
