using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;

namespace AnkiClipper
{
    public class AnkiComs
    {
        private static IAnkiAlert Alert;




        public AnkiComs(IAnkiAlert ankiAlert)
        {
            Alert = ankiAlert;
        }

        internal static void SendToAnki(string title, string content, string[] tags, string url = null)
        {
			var client = new HttpClient();

			var requestContent = new StringContent(JsonConvert.SerializeObject(new {
				action = "addNote", @params = new {
					note = new {
						deckName = "All Active::Inbox",
						modelName = "IR3",
						fields = new
						{
							Title = title,
							Text = content,
							Source = url
						},
						tags
					}
				}
			}));

			var result = client.PostAsync("http://localhost:8765", requestContent).Result;
        }

        public void SendText(string title, string content, string[] tags = null)
        {
            tags = tags ?? new string[0];

            SendToAnki(title, content, tags);
        }

        public void SendHtml(string title, string htmlcontent, string[] tags = null, string url = " ")
        {
            tags = tags ?? new string[0];

            SendToAnki(title, htmlcontent, tags, url);
        }
    }
}