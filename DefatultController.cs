using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Pharos.MPS.Mobile.Client.Common.ViewModels;

namespace MVVMTest.Views
{
	public partial class DefatultController : BaseUIViewController
	{
		DefaultViewModel _viewModel;
		
		public DefatultController (DefaultViewModel vm) : base(vm, "DefatultController", null)
		{
			_viewModel = vm;
			ListenForPropertyChanges();
		}
		
		protected override void OnViewModelPropertyChanged (string propertyName)
		{
			base.OnViewModelPropertyChanged (propertyName);
			switch (propertyName)
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
			// Tell the view model what the new value for the Last Name is
			DoWithoutTriggeringNotification (() => 
			{
				_viewModel.LastName = LastName.Text; 
			});
		}

		void HandleFirstNameValueChanged (object sender, EventArgs e)
		{
			// Tell the view model what the new value for the First Name is
			DoWithoutTriggeringNotification (() => 
			{
				_viewModel.FirstName = FirstName.Text; 
			});
		}
		
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return true;
		}
		
		partial void SetUsername (MonoTouch.Foundation.NSObject sender)
		{
			_viewModel.UsernameChanged.Execute (null);
		}
		
		partial void Finished (MonoTouch.Foundation.NSObject sender)
		{
			_viewModel.Finished.Execute(null);
		}
	}
}

