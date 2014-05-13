using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SocketIOClient;
using Core;

namespace HelloWorld_iPhone
{
	public partial class HelloWorld_iPhoneViewController : UIViewController
	{
		protected int _numberOfTimesClicked = 0;

		public HelloWorld_iPhoneViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			//---- wire up our click me button
			this.btnClickMe.TouchUpInside += (sender, e) => {
				this._numberOfTimesClicked++;
				this.lblOutput.Text = "Clicked [" +
					this._numberOfTimesClicked.ToString() + "] times!";
			};

			Execute ();
		}


		partial void actnButtonClick (NSObject sender)
		{
			this.lblOutput.Text = "Action button " +  ((UIButton)sender).CurrentTitle + " clicked.";
			Console.WriteLine("Starting TestSocketIOClient Example...");

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion


		Client socket;
		public void Execute()
		{
			MyClass mc = new MyClass ();
			mc.Execute ();

			Console.WriteLine("Starting TestSocketIOClient Example...");
			EventClient tClient = new EventClient();
			tClient.Execute();

			/*
			socket = new Client("http://127.0.0.1:3000/"); // url to nodejs 
			socket.Opened += SocketOpened;
			socket.Message += SocketMessage;
			socket.SocketConnectionClosed += SocketConnectionClosed;
			socket.Error += SocketError;

			// register for 'connect' event with io server
			socket.On("connect", (fn) =>
				{
					Console.WriteLine("\r\nConnected event...\r\n");
					Console.WriteLine("Emit Part object");

					// emit Json Serializable object, anonymous types, or strings
					Part newPart = new Part() 
					{ PartNumber = "K4P2G324EC", Code = "DDR2", Level = 1 };
					socket.Emit("partInfo", newPart);
				});

			// register for 'update' events - message is a json 'Part' object
			socket.On("update", (data) =>
				{
					Console.WriteLine("recv [socket].[update] event");
					//Console.WriteLine("  raw message:      {0}", data.RawMessage);
					//Console.WriteLine("  string message:   {0}", data.MessageText);
					//Console.WriteLine("  json data string: {0}", data.Json.ToJsonString());
					//Console.WriteLine("  json raw:         {0}", data.Json.Args[0]);

					// cast message as Part - use type cast helper
					Part part = data.Json.GetFirstArgAs<Part>();
					Console.WriteLine(" Part Level:   {0}\r\n", part.Level);
				});

			// make the socket.io connection
			socket.Connect();
			*/
		}
	}
}

