// 
// DefaultViewModel.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;
using Pharos.MPS.Mobile.Client.MVVM;
using Pharos.MPS.Mobile.Client.Common.Interfaces;
using Pharos.MPS.Mobile.Client.Common.Model;
using System.Timers;
using TinyIoC;
using TinyMessenger;

namespace Pharos.MPS.Mobile.Client.Common.ViewModels
{
	public class DefaultViewModel : ViewModelBase
	{
		public const string FirstNameProperty = "FirstName";
		public const string LastNameProperty = "LastName";
		public const string UsernameProperty = "Username";
		
		private RelayCommand _setUsername;
		private RelayCommand _finished;
		private IUser _user;
        private readonly IDispatchOnUIThread _dispatcher;

		public string FirstName
		{ 
			get
			{
				return _user.FirstName;
			}
			set
			{
				_user.FirstName = value;
				RaisePropertyChanged (FirstNameProperty);
				RaisePropertyChanged (UsernameProperty);
			}
			
		}
		
		
		public string LastName
		{ 
			get
			{
				return _user.LastName;
			}
			set
			{
				_user.LastName = value;
				RaisePropertyChanged (LastNameProperty);
				RaisePropertyChanged (UsernameProperty);
			}
		}
		
		public string Username
		{
			get
			{
				return _user.FullName;
			}
		}
		
		
		public RelayCommand UsernameChanged
		{
			get
			{
				if (_setUsername == null)
				{
					_setUsername = new RelayCommand (ResetUsername);
				}
				return _setUsername;
			}
		}
		
		public RelayCommand Finished
		{
			get
			{
				if (_finished == null)
				{
					_finished = new RelayCommand (FinishedEditing);
				}
				return _finished;
			}
		}
		
		public DefaultViewModel (IUser user)
		{
			_user = user;
			_dispatcher = TinyIoC.TinyIoCContainer.Current.Resolve<Pharos.MPS.Mobile.Client.MVVM.IDispatchOnUIThread> ();
			Timer t = new Timer (3000);
			t.Elapsed += TimerElapsed;
			t.Start();
		}

		private void TimerElapsed (object sender, ElapsedEventArgs e)
		{
			_dispatcher.Invoke (() => {
				FirstName += "."; });
		}
		
		private void ResetUsername ()
		{
			RaisePropertyChanged (UsernameProperty);
		}
		
		private void FinishedEditing()
		{
			TinyIoCContainer.Current.Resolve<ITinyMessengerHub> ().Publish (new DoneEditingUsername ());
		}
	}
}

