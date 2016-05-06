/**
 * Copyright (c) 2007-2013, Kaazing Corporation. All rights reserved.
 */
using System;
using Xamarin.Forms;

namespace KaazingWsXamarinDemo
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new KaazingWsDemoPage();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

