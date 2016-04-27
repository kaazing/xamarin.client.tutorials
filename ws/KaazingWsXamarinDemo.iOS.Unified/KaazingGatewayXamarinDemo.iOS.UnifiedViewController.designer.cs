/**
 * Copyright (c) 2007-2013, Kaazing Corporation. All rights reserved.
 */

// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace KaazingWsXamarinDemo
{
	[Register ("KaazingGatewayXamarinDemo_iOS_UnifiedViewController")]
	partial class KaazingGatewayXamarinDemo_iOS_UnifiedViewController
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
