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

namespace Pharos.MPS.Mobile.Client.Common.ViewModels
{
	public class DefaultViewModel : ViewModelBase
	{
		public const string FirstNameProperty = "FirstName";
		public const string LastNameProperty = "LastName";
		public const string UsernameProperty = "Username";
		
		private RelayCommand _setUsername;
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
		
		
		public DefaultViewModel (IUser user)
		{
			_user = user;
			_dispatcher = TinyIoC.TinyIoCContainer.Current.Resolve<Pharos.MPS.Mobile.Client.MVVM.IDispatchOnUIThread> ();
			Timer t = new Timer (3000);
			t.Elapsed += HandleTElapsed;
			t.Start();
		}

		void HandleTElapsed (object sender, ElapsedEventArgs e)
		{
			_dispatcher.Invoke(() => { FirstName += "."; });
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
		
		private void ResetUsername()
		{
			RaisePropertyChanged(UsernameProperty);
		}
	}
}

