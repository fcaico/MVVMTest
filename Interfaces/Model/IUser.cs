// 
// IUser.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;

namespace Pharos.MPS.Mobile.Client.Interfaces.Model
{
	public interface IUser
	{
		string FirstName { get; set; }
		string LastName { get; set; }
		string FullName { get; }
	}
}

