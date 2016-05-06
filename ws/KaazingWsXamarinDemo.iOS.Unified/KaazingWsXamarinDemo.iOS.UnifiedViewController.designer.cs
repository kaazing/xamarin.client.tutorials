// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace KaazingWsXamarinDemo
{
	[Register ("KaazingWsXamarinDemo_iOS_UnifiedViewController")]
	partial class KaazingWsXamarinDemo_iOS_UnifiedViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton clearButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton connectButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView logTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField messageEntry { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton sendButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField uriEntry { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (clearButton != null) {
				clearButton.Dispose ();
				clearButton = null;
			}
			if (connectButton != null) {
				connectButton.Dispose ();
				connectButton = null;
			}
			if (logTextView != null) {
				logTextView.Dispose ();
				logTextView = null;
			}
			if (messageEntry != null) {
				messageEntry.Dispose ();
				messageEntry = null;
			}
			if (sendButton != null) {
				sendButton.Dispose ();
				sendButton = null;
			}
			if (uriEntry != null) {
				uriEntry.Dispose ();
				uriEntry = null;
			}
		}
	}
}
