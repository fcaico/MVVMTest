using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pharos.MPS.Mobile.Client.Common.Model;
using Pharos.MPS.Mobile.Client.Common.ViewModels;
using MVVMTest.Views;
using TinyIoC;

namespace MVVMTest
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			TinyIoCContainer container = TinyIoCContainer.Current;
			User user = new User ("Frank", "Caico");
			DefaultViewModel viewModel = new DefaultViewModel (user);
			
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			window.RootViewController = new DefatultController (viewModel);
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}

