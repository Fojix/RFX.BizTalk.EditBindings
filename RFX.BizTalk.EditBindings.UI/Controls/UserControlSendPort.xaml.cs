using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using RFX.BizTalk.EditBindings.Core;
using RFX.BizTalk.EditBindings.Logic;

namespace RFX.BizTalk.EditBindings.UI.Controls
{
    /// <summary>
    /// Interaction logic for UserControlSendPort.xaml
    /// </summary>
    public partial class UserControlSendPort : UserControl
    {
        public UserControlSendPort(SendPort sendPort)
        {
            InitializeComponent();

            SendPortName.Content = sendPort.Name;

            RtbName.SetText(sendPort.Name);
            RtbDescription.SetText(sendPort.Description);
            RtbSendPipelineData.SetText(sendPort.SendPipelineData);

            MarkText(RtbName);
            MarkText(RtbDescription);
            MarkText(RtbSendPipelineData);

            if (sendPort.IsStatic)
            {
                RtbPrimaryTransmitData.SetText(sendPort.PrimaryTransport.Address);
                RtbPrimaryTransportType.SetText(sendPort.PrimaryTransport.TransportType.Name);
                RtbPrimaryTransmitData.SetXmlText(sendPort.PrimaryTransport.TransportTypeData);

                MarkText(RtbPrimaryTransmitData);
                MarkText(RtbPrimaryTransportType);
                MarkText(RtbPrimaryTransmitData);
            }
            else
            {
                GridTransports.Visibility = Visibility.Collapsed;
            }


        }

        private void MarkText(RichTextBox rtb)
        {
            var textrange1 = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

            textrange1.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Transparent));
            textrange1.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);

            Regex rgx = new Regex(@"(\$\((.*?)\))", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            var start = rtb.Document.ContentStart;
            while (start != null && start.CompareTo(rtb.Document.ContentEnd) < 0)
            {
                if (start.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                {
                    var match = rgx.Match(start.GetTextInRun(LogicalDirection.Forward));

                    var textrange = new TextRange(start.GetPositionAtOffset(match.Index, LogicalDirection.Forward),
                        start.GetPositionAtOffset(match.Index + match.Length, LogicalDirection.Backward));
                    textrange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(Colors.Yellow));
                    textrange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                    start = textrange.End; // I'm not sure if this is correct or skips ahead too far, try it out!!!
                }

                start = start.GetNextContextPosition(LogicalDirection.Forward);

            }
        }

        //private void RichTextBoxName_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    MarkText(RtbName);
        //}

        private void RichTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var rtb = (RichTextBox)sender;
            MarkText(rtb);
        }
    }
}
