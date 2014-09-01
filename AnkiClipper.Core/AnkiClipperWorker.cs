using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AnkiClipper
{
    using System.Linq;

    public class AnkiClipperWorker
    {
        private readonly string clipboard;

        private readonly string contentType;

        private readonly IAnkiAlert Alert;

        public AnkiClipperWorker(IAnkiClipboard ankiClipboard, IAnkiAlert ankiAlert)
        {
            this.clipboard = ankiClipboard.GetClipboardContent();
            this.contentType = ankiClipboard.CurrentType;
            Alert = ankiAlert;
        }

        public void WorkerSendToAnki(string answer)
        {

            var regexTags = new Regex(@"@([^\s]*)", RegexOptions.IgnoreCase);
            var matchTags = regexTags.Matches(answer);

            List<string> tags = (from Match itemMatch in matchTags select itemMatch.Groups[1].ToString()).ToList();

            var title = matchTags.Count > 0 ? answer.Substring(0, matchTags[0].Index - 1) : answer;

            var ankiComs = new AnkiComs(Alert);

            if (this.contentType == "HTML")
            {
                ankiComs.SendHtml(title, this.clipboard, tags.ToArray());
            }
            else
            {
                ankiComs.SendText(title, this.clipboard, tags.ToArray());
            }
        }
    }
}