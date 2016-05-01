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
using Fluent;
using Microsoft.Win32;
using RFX.BizTalk.EditBindings.Core;
using RFX.BizTalk.EditBindings.Logic;
using RFX.BizTalk.EditBindings.UI.Controls;
using MessageBox = Xceed.Wpf.Toolkit.MessageBox;


namespace RFX.BizTalk.EditBindings.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        private BindingLogic _bindingLogic;
        private readonly string WINDOWTITLE = "BizTalk Binding Toolbox";

        public MainWindow()
        {
            InitializeComponent();

            _bindingLogic = new BindingLogic();
        }

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    XmlSerializer ser = new XmlSerializer(typeof(BindingInfo));
            
        //    using (
        //        FileStream fs = new FileStream(@"C:\Projects\GIT\RFX.BizTalk.EditBindings\TempBindings.xml",
        //            FileMode.Open))
        //    {
        //        BindingInfo bi = (BindingInfo) ser.Deserialize(fs);
                
        //        using (
        //            FileStream fsOut = new FileStream(
        //                @"C:\Projects\GIT\RFX.BizTalk.EditBindings\TempBindings - OUT - " + DateTime.Now.ToString("yyMMdd_HHmmss") + ".xml", FileMode.CreateNew))
        //        {
        //            StreamWriter sw = new StreamWriter(fsOut, Encoding.UTF8);
        //            ser.Serialize(sw, bi);
        //            fsOut.Flush();
        //        }

                
        //    }
        //}
        private void BtnOpen_OnClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog {InitialDirectory = Properties.Settings.Default.FileDialogPath};
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;

                Properties.Settings.Default.FileDialogPath = System.IO.Path.GetDirectoryName(fileName);
                Properties.Settings.Default.Save();

                _bindingLogic.OpenBindingFile(fileName);

                // Set all buttons to enabled
                BtnSave.IsEnabled = true;
                BtnSaveAs.IsEnabled = true;
                BtnSortAz.IsEnabled = true;
                BtnSortZa.IsEnabled = true;
                TabControlBindings.Visibility = Visibility.Visible;
                PanelNothingToSeeHere.Visibility = Visibility.Collapsed;

                SetTitle(fileName);

                LoadSendPorts();
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_bindingLogic.EditableBindingFile == null)
            {
                MessageBox.Show("You haven't opened a binding file yet. Please open a binding file before saving.");
                return;
            }

            if (MessageBox.Show("You are about to overwrite your existing binding file. If you have done a \"Save As\" before, it will be saved as that file.\n\n Are you sure?", "Overwrite?",
                MessageBoxButton.OKCancel, MessageBoxImage.Warning)
                == MessageBoxResult.OK)
            {
                _bindingLogic.SaveBindingFile(_bindingLogic.EditableBindingFile.FileName);
            }
        }

        private void BtnSaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (_bindingLogic.EditableBindingFile == null)
            {
                MessageBox.Show("You haven't opened a binding file yet. Please open a binding file before saving.");
                return;
            }
            
            var saveFileDialog = new SaveFileDialog() { InitialDirectory = Properties.Settings.Default.FileDialogPath };
            if (saveFileDialog.ShowDialog() == true)
            {
                var fileName = saveFileDialog.FileName;

                Properties.Settings.Default.FileDialogPath = System.IO.Path.GetDirectoryName(fileName);
                Properties.Settings.Default.Save();

                _bindingLogic.SaveBindingFile(saveFileDialog.FileName);

                SetTitle(fileName);
            }
        }

        private void BtnSortAz_OnClick(object sender, RoutedEventArgs e)
        {
            _bindingLogic.SortSendPortsAz();
            LoadSendPorts();
        }

        private void SetTitle(string fileName)
        {
            this.Title = $"{WINDOWTITLE} ({fileName})";
        }

        private void LoadSendPorts()
        {
            StackPanelSendPorts.Children.Clear();
            foreach (var sendPort in _bindingLogic.EditableBindingFile.BindingInfo.SendPortCollection)
            {
                var ucSendPort = new UserControlSendPort(sendPort);
                ucSendPort.HorizontalAlignment = HorizontalAlignment.Stretch;
                
                StackPanelSendPorts.Children.Add(ucSendPort);
            }
        }
    }
}
