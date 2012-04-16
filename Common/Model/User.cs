// 
// User.cs
// Copyright (c) 2012 Pharos Systems International 2012
// 
// 
using System;
using Pharos.MPS.Mobile.Client.Interfaces.Model;

namespace Pharos.MPS.Mobile.Client.Common.Model
{
	public class User : IUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }
		
		/// <summary>
		/// Gets the full name.
		/// </summary>
		/// <value>
		/// The full name.
		/// </value>
		public string FullName
		{
			get
			{
				return FirstName + " " + LastName;	
			}	
		}
		
		public User(string first, string last)
		{
			FirstName = first;
			LastName = last;
		}
		
		
	}
}

