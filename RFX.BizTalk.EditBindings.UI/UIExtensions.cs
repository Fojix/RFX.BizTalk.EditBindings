using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using RFX.BizTalk.EditBindings.Logic;

namespace RFX.BizTalk.EditBindings.UI
{
    internal static class UIExtensions
    {
        public static void SetXmlText(this RichTextBox rtb, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd)
                {
                    Text = BindingLogic.PrintXml(text)
                };
            }
            
        }

        public static void SetText(this RichTextBox rtb, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var range = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd) {Text = text};
            }
        }

    }
}
