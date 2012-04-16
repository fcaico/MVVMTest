using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pharos.MPS.Mobile.Client.Common.ViewModels;

namespace MVVMTest.Views
{
	public partial class DefatultController : UIViewController
	{
		DefaultViewModel _viewModel;
		
		public DefatultController (DefaultViewModel vm) : base ("DefatultController", null)
		{
			_viewModel = vm;
			ListenForPropertyChanges(true);
		}
		
		void ListenForPropertyChanges (bool listen)
		{
			if (listen)
			{
				_viewModel.PropertyChanged += Handle_viewModelPropertyChanged;
			} else
			{
				_viewModel.PropertyChanged -= Handle_viewModelPropertyChanged;
			}
		}

		void Handle_viewModelPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				
				case DefaultViewModel.FirstNameProperty:
					FirstName.Text = _viewModel.FirstName;
					break;
				
				case DefaultViewModel.LastNameProperty:
					LastName.Text = _viewModel.LastName;
					break;
				
				case DefaultViewModel.UsernameProperty:
					Username.Text = _viewModel.Username;
					break;
			}
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
			if (_viewModel != null)
			{
				FirstName.Text = _viewModel.FirstName;
				LastName.Text = _viewModel.LastName;
				Username.Text = _viewModel.Username;
			}
			
			FirstName.EditingChanged += HandleFirstNameValueChanged;
			LastName.EditingChanged += HandleLastNameValueChanged;
			
		}

		void HandleLastNameValueChanged (object sender, EventArgs e)
		{
			ListenForPropertyChanges (false);
			// Tell the view model what the new value for the Last Name is
			_viewModel.LastName = LastName.Text;
			ListenForPropertyChanges(true);

		}

		void HandleFirstNameValueChanged (object sender, EventArgs e)
		{
			ListenForPropertyChanges (false);
			// Tell the view model what the new value for the First Name is
			_viewModel.FirstName = FirstName.Text;
			ListenForPropertyChanges (true);

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
		
		partial void SetUsername (MonoTouch.Foundation.NSObject sender)
		{
			_viewModel.UsernameChanged.Execute(null);
		}
	}
}

