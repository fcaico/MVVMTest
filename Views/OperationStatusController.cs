using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pharos.MPS.Mobile.Client.MVVM;
using Pharos.MPS.Mobile.Client.Common.ViewModels;

namespace MVVMTest.Views
{
	public partial class OperationStatusController : BaseUIViewController
	{
		OperationStatusViewModel _operationStatusViewModel;
		
		public OperationStatusController (OperationStatusViewModel viewModel) : base (viewModel, "OperationStatusController", null)
		{
			_operationStatusViewModel = viewModel;
			ListenForPropertyChanges();
		}
		
		
		protected override void OnViewModelPropertyChanged (string propertyName)
		{
			base.OnViewModelPropertyChanged (propertyName);

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
			switch (_operationStatusViewModel.BackgroundColor)
			{
				case OperationStatusColor.Green:
					View.BackgroundColor = new UIColor (0f, 1.0f, 0f, 1.0f);
					break;
					
				case OperationStatusColor.Red:
					View.BackgroundColor = new UIColor (1.0f, 0f, 0f, 1.0f);
					break;
			}
			
			StatusMessage.Text = _operationStatusViewModel.StatusMessage;
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

