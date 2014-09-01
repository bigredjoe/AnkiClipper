using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;

using System.Linq;

namespace AnkiClipper
{
    public class AnkiComs
    {
        private static IAnkiAlert Alert;

        public AnkiComs(IAnkiAlert ankiAlert)
        {
            Alert = ankiAlert;
        }

        internal static void SendToAnki(string xmlContent)
        {
            string xmlFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + Path.DirectorySeparatorChar + "text.xml";
            TextWriter writer = new StreamWriter(xmlFile);

            //writer.WriteLine((string)od.GetData(DataFormats.Html, true));
            writer.WriteLine(xmlContent);
            writer.Close();
            var localhost = IPAddress.Parse("127.0.0.1");
            var endPoint = new IPEndPoint(localhost, 49666);

            // This is how you can determine whether a socket is still connected.
            var s = new Socket(endPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            bool blockingState = s.Blocking;
            try
            {
                s.Connect(endPoint);

                string file = xmlFile.Replace(@"\\", "\\");
                byte[] msg = Encoding.ASCII.GetBytes(file);

                s.Blocking = false;
                s.Send(msg);
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK
                if (e.NativeErrorCode.Equals(10035))
                {
                    Console.WriteLine(@"Still Connected, but the Send would block");
                }
                    
                else
                {
                    Alert.SendAlert("Error", "Make sure Anki is open.");
                }
            }
            finally
            {
                s.Blocking = blockingState;
                s.Close();
            }
        }

        public void SendText(string title, string content, string[] tags = null)
        {
            tags = tags ?? new string[0];

            XElement flashcard = GenerateXml(
                "Basic (Test)",
                "Forward",
                new Dictionary<string, string>()
                    {
                        { "qfmt", "{{Front}}\n{{type:Back}}" },
                        { "afmt", "{{FrontSide}}\n{{Back}}" }
                    },
                new Dictionary<string, string>() { { "Front", title }, { "Back", content } },
                tags);

            SendToAnki(flashcard.ToString());
        }

        public void SendHtml(string title, string htmlcontent, string[] tags = null, string url = " ")
        {
            tags = tags ?? new string[0];

            XElement flashcard = GenerateXml(
                "IRead2",
                "Forward",
                new Dictionary<string, string>()
                    {
                        { "qfmt", "<h1>{{Title}}</h1>\n<p>{{Text}}</p>\n\n- {{Source}}" },
                        { "afmt", "{{FrontSide}}" }
                    },
                new Dictionary<string, string>() { { "Title", title }, { "Text", htmlcontent }, { "Source", url } },
                tags);

            SendToAnki(flashcard.ToString());
        }

        private static XElement GenerateXml(string cardType, string templateName, Dictionary<string, string> template, Dictionary<string, string> fields, string[] tags, string css = "")
        {
            var returnXml = new XElement(
                "command",
                new XAttribute("name", "add-notes"),
                new XAttribute("version", "1.0"),
                new XElement(
                    "models",
                    new XElement(
                        "model",
                        new XElement("name", cardType),
                        new XElement("type", "MODEL_STD"),
                        new XElement("css", " { \n" + css + "\n}")),
                    new XElement(
                        "fields",
                        from field in fields
                        select new XElement(
                            "field",
                            new XElement("name", field.Key))),
                    new XElement(
                        "templates",
                        new XElement(
                            "template",
                            new XElement("name", "Forward"),
                            from tField in template.Keys select new XElement(tField, template[tField])))),
                new XElement(
                    "notes",
                    new XElement(
                        "note",
                        new XElement("model", cardType),
                        new XElement("deck", "Default"),
                        new XElement("tags", new XElement("tag", " " + string.Join(" ", tags))),
                        new XElement(
                            "fields",
                            from field in fields
                            select new XElement(
                                "field",
                                new XElement("name", field.Key),
                                new XElement("content", field.Value))))));
            return returnXml;
        }
    }
}