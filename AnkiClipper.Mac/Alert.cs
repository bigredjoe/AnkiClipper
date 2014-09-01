using System;
using MonoMac.AppKit;

namespace AnkiClipper
{
	public class Alert : IAnkiAlert
	{

		public Alert ()
		{
		}

		public void SendAlert(string title, string message)
		{
			var alert = new NSAlert();
			alert.MessageText = title;
			alert.InformativeText = message;
			alert.RunModal();
		}
	}
}

