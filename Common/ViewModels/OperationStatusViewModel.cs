// 
// OperationStatusViewModel.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;
using Pharos.MPS.Mobile.Client.MVVM;

namespace Pharos.MPS.Mobile.Client.Common.ViewModels
{
	public enum OperationStatusColor
	{
		Green,
		Red
	}
	
	public class OperationStatusViewModel : ViewModelBase
	{
		public const string BackgroundColorProperty = "BackgroundColor";
		public const string StatusMessageProperty = "StatusMessage";
	
		protected OperationStatusColor _backgroundColor;
		protected string _statusMessage;
		
		public OperationStatusColor BackgroundColor
		{
			get
			{
				return _backgroundColor;
			}
			set
			{
				if (_backgroundColor != value)
				{
					_backgroundColor = value;
					RaisePropertyChanged (BackgroundColorProperty);
				}
			}
		}
		
		public string StatusMessage
		{
			get
			{
				return _statusMessage;
			}
			set
			{
				if (_statusMessage != value)
				{
					_statusMessage = value;
					RaisePropertyChanged (StatusMessageProperty);
				}
			}
		}
		
		
		public OperationStatusViewModel (bool success, string message)
		{
			BackgroundColor = success ? OperationStatusColor.Green : OperationStatusColor.Red;
			StatusMessage = message;
		}
	}
}

