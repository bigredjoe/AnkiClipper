using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkiClipper
{
    public interface IAnkiClipboard
    {
        string CurrentType { get; set; }
        string GetClipboardContent();
    }
}
