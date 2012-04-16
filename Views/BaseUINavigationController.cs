// 
// BaseUIViewController.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Pharos.MPS.Mobile.Client.MVVM;

namespace MVVMTest.Views
{
	public class BaseUINavigationController: UINavigationController
	{
		private ViewModelBase _viewModel;
		
		protected virtual void ListenForPropertyChanges ()
		{
			// Subscribe to the Property Changed event in the view model
			_viewModel.PropertyChanged += HandleViewModelPropertyChanged;
		}
		
		protected virtual void StopListeningForPropertyChanges ()
		{
			// unsubscribe from the property changed event in the view model
			_viewModel.PropertyChanged -= HandleViewModelPropertyChanged;			
		}
		
		protected virtual void HandleViewModelPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			OnViewModelPropertyChanged(e.PropertyName);
		}
		
		protected virtual void OnViewModelPropertyChanged (string propertyName)
		{	
			// This will need to be overridden by interested parties.
		}
		
		protected virtual void DoWithoutTriggeringNotification (Action action)
		{
			StopListeningForPropertyChanges ();
			action.Invoke ();
			ListenForPropertyChanges ();
		}
		
		
		public BaseUINavigationController (ViewModelBase viewModel) : base()
		{
			_viewModel = viewModel;
		}
		
		public BaseUINavigationController (ViewModelBase viewModel, NSCoder coder) : base(coder)
		{
			_viewModel = viewModel;
		}
		
		public BaseUINavigationController (ViewModelBase viewModel, NSObjectFlag t) : base(t)
		{
			_viewModel = viewModel;
		}
		
		public BaseUINavigationController (ViewModelBase viewModel, IntPtr handle) : base(handle)
		{
			_viewModel = viewModel;
		}
		
		public BaseUINavigationController (ViewModelBase viewModel, string nibName, NSBundle bundle) : base (nibName, bundle)
		{
			_viewModel = viewModel;
		}
	}
}

