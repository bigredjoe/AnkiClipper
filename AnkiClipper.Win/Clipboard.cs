using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using AnkiClipper;

namespace AnkiClipper
{
    public class Clipboard : IAnkiClipboard
    {

        public string CurrentType
        {
            get; set; 
        }

        public string GetClipboardContent()
        {
            string contents;

            IDataObject od = System.Windows.Forms.Clipboard.GetDataObject();
            if (od.GetDataPresent(DataFormats.Html))
            {
                contents = (string)od.GetData(DataFormats.Html, true);
                contents = contents.Remove(contents.IndexOf("<!--EndFragment-->", StringComparison.Ordinal));
                contents = contents.Substring(contents.IndexOf("<!--StartFragment-->", StringComparison.Ordinal) + "<!--StartFragment-->".Length);
                CurrentType = "HTML";
            }
            else
            {
                contents = (string) od.GetData(DataFormats.Text, true);
            }
            return contents;
        }
    }
}
