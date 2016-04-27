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
                FileStream fs = new FileStream(@"C:\Projects\GIT\RFX.BizTalk.EditBindings\TempBindings - 02.xml",
                    FileMode.Open))
            {
                BindingInfo bi = (BindingInfo) ser.Deserialize(fs);

                using (
                    FileStream fsOut = new FileStream(
                        @"C:\Projects\GIT\RFX.BizTalk.EditBindings\TempBindings - OUT.xml", FileMode.CreateNew))
                {
                    ser.Serialize(fsOut, bi);
                    fsOut.Flush();
                }

                
            }
        }
    }
}
