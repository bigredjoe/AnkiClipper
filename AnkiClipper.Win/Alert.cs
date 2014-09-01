using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AnkiClipper
{
    public class Alert : IAnkiAlert
    {
        public void SendAlert(string title, string message)
        {
            MessageBox.Show(message, title);
        }
    }
}
