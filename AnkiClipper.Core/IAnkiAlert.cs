using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkiClipper
{
    public interface IAnkiAlert
    {
        void SendAlert(string title, string message);
    }
}
