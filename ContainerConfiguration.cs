using System;
using Pharos.MPS.Mobile.Client.Common.Interfaces;
using Pharos.MPS.Mobile.Client.Common.Model;
using Pharos.MPS.Mobile.Client.Common.ViewModels;
using Pharos.MPS.Mobile.Client.MVVM;
using MonoTouch.Foundation;
using TinyMessenger;
using TinyIoC;

namespace MVVMTest
{
	public class ContainerConfiguration
	{
		public static void Configure (NSObject owner)
		{
			TinyIoCContainer container = TinyIoC.TinyIoCContainer.Current;
			
			container.Register<IDispatchOnUIThread> (new Dispatcher (owner));			
			container.Register (new DefaultViewModel (new User ("Frank", "Caico")), "DefaultViewModel");
			container.Register (new ApplicationViewModel(), "ApplicationViewModel");
		}			
	}
	
	public class Dispatcher : IDispatchOnUIThread
	{
		private readonly NSObject _owner;
		
		public Dispatcher(NSObject owner)
		{
			_owner = owner;
		}
		
		public void Invoke (Action action)
		{			
			_owner.BeginInvokeOnMainThread(new NSAction(action));
		}		
	}
}