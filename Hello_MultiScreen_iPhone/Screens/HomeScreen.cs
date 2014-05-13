using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hello_MultiScreen_iPhone
{
	public partial class HomeScreen : UIViewController
	{
		HelloWorldScreen _helloWorldScreen;
		HelloWorldScreen helloWorldScreen 
		{
			get 
			{ 
				if (_helloWorldScreen == null)
					_helloWorldScreen = new HelloWorldScreen ();
				return _helloWorldScreen;
			}
			set
			{
				_helloWorldScreen = value;
			}
		}

		HelloUniverseScreen _helloUniverseScreen;
		HelloUniverseScreen helloUniverseScreen
		{
			get 
			{ 
				if (_helloUniverseScreen == null)
					_helloUniverseScreen = new HelloUniverseScreen ();
				return _helloUniverseScreen;
			}
			set
			{
				_helloUniverseScreen = value;
			}
		}

		public HomeScreen () : base ("HomeScreen", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnHelloWorld.TouchUpInside += (sender, e) => {
				//---- instantiate a new hello world screen, if it's null
				// (it may not be null if they've navigated backwards
				//---- push our hello world screen onto the navigation
				//controller and pass a true so it navigates
				NavigationController.PushViewController(helloWorldScreen, true);
			};

			btnHelloUniverse.TouchUpInside += (sender, e) => {
				//---- instantiate a new hello world screen, if it's null
				// (it may not be null if they've navigated backwards
				//---- push our hello world screen onto the navigation
				//controller and pass a true so it navigates
				NavigationController.PushViewController(new HelloUniverseScreen(), true);
			};
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			NavigationController.SetNavigationBarHidden (true, animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
			NavigationController.SetNavigationBarHidden (false, animated);
		}
	}
}

