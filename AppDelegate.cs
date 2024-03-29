using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pharos.MPS.Mobile.Client.Common.Model;
using Pharos.MPS.Mobile.Client.Common.ViewModels;
using Pharos.MPS.Mobile.Client.MVVM;
using MVVMTest.Views;
using TinyIoC;
using TinyMessenger;

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
			ContainerConfiguration.Configure (this);
			
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			//window.RootViewController = new DefatultController (TinyIoCContainer.Current.Resolve<DefaultViewModel> ("DefaultViewModel"));
			window.RootViewController = new ApplicationController (TinyIoCContainer.Current.Resolve<ApplicationViewModel> ("ApplicationViewModel"));
	
			ITinyMessengerHub messageHub = TinyIoCContainer.Current.Resolve<ITinyMessengerHub> ();
			messageHub.Publish(new ApplicationStartingMessage());
			
			// make the window visible
			window.MakeKeyAndVisible ();
			
			
			
			return true;
		}
	}
}

