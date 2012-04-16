// 
// ApplicationModel.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;
using TinyMessenger;
using TinyIoC;
using Pharos.MPS.Mobile.Client.MVVM;
using Pharos.MPS.Mobile.Client.Common.Model;

namespace Pharos.MPS.Mobile.Client.Common.ViewModels
{
	public class ApplicationStartingMessage : ITinyMessage
	{
		/// <summary>
	    /// The sender of the message, or null if not supported by the message implementation.
	    /// </summary>
	    public object Sender
		{ 
			get; 
			private set; 
		}
	}
	
	public class ApplicationFinishingMessage : ITinyMessage
	{
		/// <summary>
	    /// The sender of the message, or null if not supported by the message implementation.
	    /// </summary>
	    public object Sender
		{ 
			get; 
			private set; 
		}
	}
	
	public class DoneEditingUsername : ITinyMessage
	{
		/// <summary>
	    /// The sender of the message, or null if not supported by the message implementation.
	    /// </summary>
	    public object Sender
		{ 
			get; 
			private set; 
		}
	}
	
	
	
	public class ApplicationViewModel : ViewModelBase
	{
		public const string CurrentViewModelProperty = "CurrentViewModel";
		
		private ITinyMessengerHub _messageHub;
		private ViewModelBase _currentViewModel;
		
		public ViewModelBase CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
			set
			{
				if (_currentViewModel != value)
				{
					_currentViewModel = value;
					RaisePropertyChanged (CurrentViewModelProperty);
				}
			}
		}
		
		
		private void StartApplication ()
		{
			CurrentViewModel = new DefaultViewModel(new User("Frank", "Caico"));
		}
		
		
		private void TerminateApplication ()
		{
			
		}
		
		private void ShowUserEditing ()
		{
			
		}
		
		private void ShowSuccess ()
		{
			CurrentViewModel = new OperationStatusViewModel(true, "Success!");
		}
		
		private void ShowFailure ()
		{
			CurrentViewModel = new OperationStatusViewModel (false, "Failure!");
		}
		
		private void EvaluateSuccess ()
		{
			bool success = true;
			if (success)
			{
				ShowSuccess ();	
			} else
			{
				ShowFailure ();
			}
			
		}
		
		public ApplicationViewModel ()
		{
			_messageHub = TinyIoCContainer.Current.Resolve<ITinyMessengerHub> ();
			
			_messageHub.Subscribe<ApplicationStartingMessage> ((a) => StartApplication());
			_messageHub.Subscribe<DoneEditingUsername> ((a) => EvaluateSuccess());
			_messageHub.Subscribe<ApplicationFinishingMessage> ((a) => TerminateApplication());
		}
	}
}

