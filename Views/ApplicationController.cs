using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pharos.MPS.Mobile.Client.MVVM;
using Pharos.MPS.Mobile.Client.Common.ViewModels;

namespace MVVMTest.Views
{
	public partial class ApplicationController : BaseUINavigationController
	{
		ApplicationViewModel _appViewModel;
		
		public ApplicationController (ViewModelBase viewModel) : base(viewModel)
		{
			_appViewModel = viewModel as ApplicationViewModel;
			ListenForPropertyChanges();
		}
		
		protected override void OnViewModelPropertyChanged (string propertyName)
		{
			base.OnViewModelPropertyChanged (propertyName);
			
			switch (propertyName)
			{
				case ApplicationViewModel.CurrentViewModelProperty:
					ViewModelBase vm = _appViewModel.CurrentViewModel;
					ShowController(GetControllerForViewModel(vm));
					break;
			}
		}
		
		
		protected UIViewController GetControllerForViewModel (ViewModelBase viewModel)
		{
			if (viewModel.GetType () == typeof(DefaultViewModel))
			{
				return new DefatultController (viewModel as DefaultViewModel);
			}
			else if (viewModel.GetType () == typeof(OperationStatusViewModel))
			{
				return new OperationStatusController (viewModel as OperationStatusViewModel);
			}
			else
			{
				return null;
			}
		}
		
		protected void ShowController (UIViewController controller)
		{
			base.PushViewController(controller, true);
		}
		
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}
	}
}

