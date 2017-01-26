using System;
using MonoMac.AppKit;
using AnkiClipper;

namespace AnkiClipper
{
	public class Clipboard : IAnkiClipboard
	{
		public string CurrentType {
			get;
			set;
		}

		private readonly NSPasteboard clipboard = NSPasteboard.GeneralPasteboard;

		public string GetClipboardContent()
		{
			string clipboardContents = "";
			if (clipboard.GetStringForType("public.html") != null)
			{
				clipboardContents = clipboard.GetStringForType("public.html");
				CurrentType = "HTML";
			}
			else if (clipboard.GetStringForType("NSStringPboardType") != null)
			{
				clipboardContents = clipboard.GetStringForType("NSStringPboardType");
				CurrentType = "Text";
			}
			return clipboardContents;
		}

	}
}

