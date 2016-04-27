/**
 * Copyright (c) 2007-2013, Kaazing Corporation. All rights reserved.
 */

using System;
using System.Drawing;
using Kaazing.Security;
using System.Threading.Tasks;
using Kaazing.HTML5;
using System.Threading;

using Foundation;
using UIKit;

namespace KaazingWsXamarinDemo
{
	public partial class KaazingGatewayXamarinDemo_iOS_UnifiedViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		bool _isConnected = false;
		WebSocket _webSocket = null;

		public KaazingGatewayXamarinDemo_iOS_UnifiedViewController (IntPtr handle) : base(handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad();

			EnableUI(false);


			_webSocket = new WebSocket();

			BasicChallengeHandler basicHandler = ChallengeHandlers.Load<BasicChallengeHandler>(typeof(BasicChallengeHandler));
			basicHandler.LoginHandler = new LoginHandlerDemo(this);
			ChallengeHandlers.Default = basicHandler;

			_webSocket.OpenEvent += new OpenEventHandler(OpenHandler);
			_webSocket.CloseEvent += new CloseEventHandler(CloseHandler);
			_webSocket.MessageEvent += new MessageEventHandler(MessageHandler);

			connectButton.TouchUpInside += async (sender, e) => {
				try {
					if (!_isConnected) {
						string uri = uriEntry.Text;
						Log("CONNECTING: " + uri);
						connectButton.Enabled=false;	
						await Task.Factory.StartNew(() => {
							_webSocket.Connect(uri);
						});
					} else {
						Log("CLOSING");
						_webSocket.Close();
					}

				} catch(Exception exc) {
					connectButton.Enabled=true;
					Log("CONNECTION FAILED: " + exc.Message);
					EnableUI(false);
				}
			}; 

			sendButton.TouchUpInside +=  async (sender, e) => {
				string messageInput = messageEntry.Text;

				await Task.Factory.StartNew(() => {
					_webSocket.Send (messageInput);
				});
				Log("SEND: " + messageInput);
			};

			clearButton.TouchUpInside += (sender, e) => logTextView.Text = "";

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear(animated);
		}

		#endregion

		///
		/// HTML5 Event Handlers
		///
		private void OpenHandler(object sender, OpenEventArgs args)
		{
			// Enable User Interface for Connected application
			connectButton.Enabled=true;
			EnableUI(true);
			Log("CONNECTED");
		}

		private void CloseHandler(object sender, CloseEventArgs args)
		{
			EnableUI(false);
			Log("DISCONNECTED");
		}

		private void MessageHandler(object sender, MessageEventArgs args)
		{
			/*
			 * 
			Change once the proper DLLs are working...
			switch(args.MessageType) {
			case EventType.BINARY:
				Log("BINARY MESSAGE: "+  BitConverter.ToString(args.Data.Array));
				break;
			case EventType.TEXT:
				Log("TEXT MESSAGE: " + System.Text.Encoding.UTF8.GetString(args.Data.Array, 0, args.Data.Array.Length));
				break;
			case EventType.CLOSE:
				Log("CLOSED");
				break;

			}*/
			Log("RECIEVED MESSAGE: " + args.Data);
		}

		public void EnableUI(bool enable)
		{
			InvokeOnMainThread(delegate {  
				if (enable) {
					_isConnected = true;
					connectButton.SetTitle("Disconnect", UIControlState.Normal);
					sendButton.Enabled = true;
				} else {
					_isConnected = false;
					connectButton.SetTitle("Connect", UIControlState.Normal);
					sendButton.Enabled = false;
				}
			});
		}

		public void Log(string message)
		{
			InvokeOnMainThread(delegate {  
				logTextView.Text = logTextView.Text + "\n" + message;
			});
		}

		public PasswordAuthentication AuthenticationHandler()
		{
			PasswordAuthentication credentials = null;
			AutoResetEvent userInputCompleted = new AutoResetEvent(false);

			InvokeOnMainThread(delegate {  
				UIAlertView alertView = new UIAlertView();
				alertView.AlertViewStyle = UIAlertViewStyle.LoginAndPasswordInput;
				alertView.Title = "Login Form";
				alertView.AddButton("Login");
				alertView.Show();
				alertView.Clicked += (sender, buttonArgs) => { 
					credentials = new PasswordAuthentication(alertView.GetTextField(0).Text, alertView.GetTextField(1).Text.ToCharArray());
					userInputCompleted.Set();
				};
			});
			// wait user click 'Login' on login window
			userInputCompleted.WaitOne();

			return credentials;
		}

		class LoginHandlerDemo : LoginHandler
		{
			private KaazingGatewayXamarinDemo_iOS_UnifiedViewController _controller;

			/// <summary>
			/// constructor
			/// <para>pass in main form for callback</para>
			/// </summary>
			/// <param name="form"></param>
			public LoginHandlerDemo(KaazingGatewayXamarinDemo_iOS_UnifiedViewController controller)
			{
				_controller = controller;
			}

			#region LoginHandler Members

			PasswordAuthentication LoginHandler.GetCredentials()
			{
				return _controller.AuthenticationHandler();
			}

			#endregion
		}
	}
}

