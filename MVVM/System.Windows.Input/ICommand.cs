// 
// ICommand.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;

namespace System.Windows.Input
{
	public interface ICommand
	{
		event EventHandler CanExecuteChanged;

		bool CanExecute (object parameter);

		void Execute (object parameter);
	}
}

