// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MVVMTest.Views
{
	[Register ("DefatultController")]
	partial class DefatultController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField FirstName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField LastName { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel Username { get; set; }

		[Action ("SetUsername:")]
		partial void SetUsername (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (FirstName != null) {
				FirstName.Dispose ();
				FirstName = null;
			}

			if (LastName != null) {
				LastName.Dispose ();
				LastName = null;
			}

			if (Username != null) {
				Username.Dispose ();
				Username = null;
			}
		}
	}
}
