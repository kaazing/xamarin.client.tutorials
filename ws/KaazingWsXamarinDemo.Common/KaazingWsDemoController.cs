/**
 * Copyright (c) 2007-2013, Kaazing Corporation. All rights reserved.
 */

using System;
using Xamarin.Forms;
using System.Collections.Generic;
using Kaazing.Security;
using System.Threading.Tasks;
using Kaazing.HTML5;
using System.Threading;
using System.Diagnostics;

namespace KaazingWsXamarinDemo
{
    public class KaazingWsDemoController
    {
		protected KaazingWsDemoPage _demoPage;

        bool _isConnected = false;
        string _username = null;
        string _password = null;
        AutoResetEvent _userInputCompleted;

		WebSocket _webSocket = null;

		public KaazingWsDemoController(KaazingWsDemoPage demoPage)
        {
            _demoPage = demoPage;

			_webSocket = new WebSocket();

            BasicChallengeHandler basicHandler = ChallengeHandlers.Load<BasicChallengeHandler>(typeof(BasicChallengeHandler));
            basicHandler.LoginHandler = new KaazingDemoLoginHandler(this);
            ChallengeHandlers.Default = basicHandler;

			_webSocket.OpenEvent += new OpenEventHandler(OpenHandler);
			_webSocket.CloseEvent += new CloseEventHandler(CloseHandler);
			_webSocket.MessageEvent += new MessageEventHandler(MessageHandler);

            _userInputCompleted = new AutoResetEvent(false);
        }

        public void SetUsernameAndPassword(string username, string password)
        {
            _username = username;
            _password = password;

            // Once the member variables are set, now unblock the other
            // thread so that it can create credentials using the username/password.
            _userInputCompleted.Set();
        }

		public async void ConnectOrDisconnect(object sender, EventArgs eventArgs)
        {
            try {
                if (!_isConnected) {
                    string uriInput = _demoPage.URI;
                    _demoPage.Log("CONNECTING: " + uriInput);
					_demoPage.wainForConnect (true);
                    await Task.Factory.StartNew(() => {
						_webSocket.Connect(uriInput);
                    });
                } else {
					_demoPage.Log("CLOSING");
					await Task.Factory.StartNew(() => {
						_webSocket.Close ();
					});
                }

            } catch(Exception exc) {
				_demoPage.wainForConnect (false);
                _demoPage.Log("CONNECTION FAILED: " + exc.Message);
            }
        }

		///
		/// HTML5 Event Handlers
		///
		private void OpenHandler(object sender, OpenEventArgs args)
		{
			// Enable User Interface for Connected application
			_demoPage.wainForConnect (false);
			_demoPage.EnableUI(true);
			_isConnected = true;
			_demoPage.Log("CONNECTED");
		}

		private void CloseHandler(object sender, CloseEventArgs args)
		{
			_demoPage.EnableUI(false);
			_isConnected = false;
			_demoPage.Log("DISCONNECTED");
		}

		private void MessageHandler(object sender, MessageEventArgs args)
		{
			switch(args.MessageType) {
			case EventType.BINARY:
				_demoPage.Log("BINARY MESSAGE: "+  BitConverter.ToString(args.Data.Array));
				break;
			case EventType.TEXT:
				_demoPage.Log("TEXT MESSAGE: " + System.Text.Encoding.UTF8.GetString(args.Data.Array, 0, args.Data.Array.Length));
				break;
			case EventType.CLOSE:
				_demoPage.Log("CLOSED");
				break;

			}
		}
//
        async public void SendMessage(object sender, EventArgs eventArgs)
        {
            string messageInput = _demoPage.Message;

            await Task.Factory.StartNew(() => {
				_webSocket.Send (messageInput);
            });
            _demoPage.Log("SEND: " + messageInput);
        }

        public void ClearLog(object sender, EventArgs eventArgs)
		{
			Device.BeginInvokeOnMainThread(() => {
				_demoPage.LogView = "";
			});
		}
//
        public  PasswordAuthentication AuthenticationHandler()
        {
            PasswordAuthentication credentials = null;
            try {
                _userInputCompleted.Reset();
                Device.BeginInvokeOnMainThread(() => {
                    _demoPage.Navigation.PushModalAsync(new KaazingDemoLoginPage(this));
                });
                _userInputCompleted.WaitOne();
                credentials = new PasswordAuthentication(_username, _password.ToCharArray());
            } catch(Exception ex) {
                _demoPage.Log(ex.Message);
            }
            return credentials;
        }
    }
}

