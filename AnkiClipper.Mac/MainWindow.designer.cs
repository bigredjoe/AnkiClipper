// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace AnkiClipper.Mac
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButtonCell btnContinue { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField txtAnswer { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnContinue != null) {
				btnContinue.Dispose ();
				btnContinue = null;
			}

			if (txtAnswer != null) {
				txtAnswer.Dispose ();
				txtAnswer = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
