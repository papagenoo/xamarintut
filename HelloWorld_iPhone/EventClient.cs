using System;
using SocketIOClient;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using SocketIOClient.Messages;
using System.Net;
using System.Collections.Specialized;
using Core;

namespace HelloWorld_iPhone
{
	public class EventClient
	{
		Client socket;

		//class Part { PartNumber = "K4P2G324EC", Code = "DDR2", Level = 1 };

		public void Execute()
		{
			Console.WriteLine("Starting TestSocketIOClient Example...");

			var headers = new NameValueCollection
			{
				{
					"Cookie",
					"SID=7fmir6ps5ksdt9fo1dr76c7to7"
				}
			};

			//socket = new Client("http://prestashop:8081"); // url to nodejs 
			socket = new Client("https://wsbeta.tradernet.ru:443", WebSocket4Net.WebSocketVersion.Rfc6455, headers); // url to nodejs 
			//http://prestashop:8081/
			socket.Opened += SocketOpened;
			socket.Message += SocketMessage;
			socket.SocketConnectionClosed += SocketConnectionClosed;
			socket.Error += SocketError;
			socket.Connect();

//			socket.On("q", (data) =>
//			{
//				Console.WriteLine(">q", data.RawMessage);
//				Console.WriteLine(">q", data.Json.ToJsonString());
//			});
//
//			socket.On("sup_updateTransactions", (data) =>
//				{
//					Console.WriteLine(">sup_updateTransactions", data.RawMessage);
//					Console.WriteLine(">sup_updateTransactions", data.Json.ToJsonString());
//				});
//
//			socket.On("server_message", (data) =>
//				{
//					Console.WriteLine("server_message", data);
//					Console.WriteLine(data);
//					Console.WriteLine("  raw message:      {0}", data.RawMessage);
//					Console.WriteLine("  string message:   {0}", data.MessageText);
//					Console.WriteLine("  json data string: {0}", data.Json.ToJsonString());
//        			//Part part = data.Json.GetFirstArgAs<Part>();
//					//Console.WriteLine(" Part Level:   {0}\r\n", part.Level);
//
//				});

			// register for 'connect' event with io server
//			socket.On("connect", (fn) =>
//				{
//					Console.WriteLine("Connected event...");
//					Console.WriteLine("Emit Part object");
//
//					// emit Json Serializable object, anonymous types, or strings
////					Part newPart = new Part() 
////					{ 
////						PartNumber = "K4P2G324EC", 
////						Code = "DDR2", 
////						Level = 1 
////					};
//					//socket.Emit("partInfo", newPart);
//					//socket.Emit("message", new int[] { 372134,371014,157050,371012,371033 });
//					socket.Emit("sup_subscribeTransactions", new int[] { 372134,371014,157050,371012,371033 });
//					socket.Emit("sup_updateSecurities2", new string[] { "RIH4","SIH4","SRH4","EUH4","BRG4","SBER","RTKM","EDH4","GZH4","GAZPM","GDH4","LKOH","GMKN","ROSN","PLZL","BRF4","GUH4","OMC.US","TXN.US","TYC.US","MAR.US","NKE.US","CTSH.US","CHK.US","GD.US","CHRW.US","KMX.US","RU000A0JQC49","RU000A0JQC56","RU000A0JR0A9","RU000A0JSG43","RU000A0JS546","RU000A0JRHL1","RU000A0JREU9","RU000A0JQYZ8","RU000A0JQZ00","RU000A0JTCM6","RU000A0JUBD5","SU25076RMFS9","SU26207RMFS9","RU000A0JRG44","RU000A0JTX33","SU25077RMFS7","RU000A0JS8R5","RU000A0JU179","RU000A0JU963","SU26212RMFS9","GAZPM","SBER","MGNT","LKOH","GMKN","ROSN","VTBR","URKA","SNGSP","SBERP","RIM4","ESM14.US","UXM4" });
//
//				});

//			socket.Emit("message", new int[] { 372134,371014,157050,371012,371033 });
//			socket.Emit("sup_subscribeTransactions", new int[] { 372134,371014,157050,371012,371033 });
//			socket.Emit("sup_updateSecurities2", new string[] { "RIH4","SIH4","SRH4","EUH4","BRG4","SBER","RTKM","EDH4","GZH4","GAZPM","GDH4","LKOH","GMKN","ROSN","PLZL","BRF4","GUH4","OMC.US","TXN.US","TYC.US","MAR.US","NKE.US","CTSH.US","CHK.US","GD.US","CHRW.US","KMX.US","RU000A0JQC49","RU000A0JQC56","RU000A0JR0A9","RU000A0JSG43","RU000A0JS546","RU000A0JRHL1","RU000A0JREU9","RU000A0JQYZ8","RU000A0JQZ00","RU000A0JTCM6","RU000A0JUBD5","SU25076RMFS9","SU26207RMFS9","RU000A0JRG44","RU000A0JTX33","SU25077RMFS7","RU000A0JS8R5","RU000A0JU179","RU000A0JU963","SU26212RMFS9","GAZPM","SBER","MGNT","LKOH","GMKN","ROSN","VTBR","URKA","SNGSP","SBERP","RIM4","ESM14.US","UXM4" });

			// register for 'update' events - message is a json 'Part' object
//			socket.On("update", (data) =>
//				{
//					Console.WriteLine("recv [socket].[update] event");
//					//Console.WriteLine("  raw message:      {0}", data.RawMessage);
//					//Console.WriteLine("  string message:   {0}", data.MessageText);
//					//Console.WriteLine("  json data string: {0}", data.Json.ToJsonString());
//					//Console.WriteLine("  json raw:         {0}", data.Json.Args[0]);
//
//					// cast message as Part - use type cast helper
//					Part part = data.Json.GetFirstArgAs<Part>();
//					Console.WriteLine(" Part Level:   {0}\r\n", part.Level);
//				});

			// make the socket.io connection


			var logger = socket.Connect("/sup"); // connect to the logger ns
			socket.Message += SocketMessage;

			logger.On("sup_updateTransactions", (data) =>
				{
					Console.WriteLine("t: {0}", data.RawMessage);
					//Console.WriteLine(">sup_updateTransactions", data.Json.ToJsonString());
				});
			logger.On("q", (data) =>
				{
					QuotesUpdateEvent quotesUpdate = data.Json.GetFirstArgAs<QuotesUpdateEvent>();
					//Console.WriteLine("q: {0}", data.MessageText);
					Console.WriteLine(">q: {0}", quotesUpdate);
				});

			socket.On("connect", (fn) =>
				{
					Console.WriteLine("\r\nConnected event...\r\n");
					Console.WriteLine("Emit Part object");

					// emit Json Serializable object, anonymous types, or strings
					//					Part newPart = new Part() 
					//					{ 
					//						PartNumber = "K4P2G324EC", 
					//						Code = "DDR2", 
					//						Level = 1 
					//					};
					//socket.Emit("partInfo", newPart);
					//socket.Emit("message", new int[] { 372134,371014,157050,371012,371033 });
					socket.Emit("sup_subscribeTransactions", new int[] { 372134,371014,157050,371012,371033 });
				});

			logger.Emit("sup_subscribeTransactions", new int[] { 372134,371014,157050,371012,371033 });
			logger.Emit("sup_updateSecurities2", new string[] { "RIH4","SIH4","SRH4","EUH4","BRG4","SBER","RTKM","EDH4","GZH4","GAZPM","GDH4","LKOH","GMKN","ROSN","PLZL","BRF4","GUH4","OMC.US","TXN.US","TYC.US","MAR.US","NKE.US","CTSH.US","CHK.US","GD.US","CHRW.US","KMX.US","RU000A0JQC49","RU000A0JQC56","RU000A0JR0A9","RU000A0JSG43","RU000A0JS546","RU000A0JRHL1","RU000A0JREU9","RU000A0JQYZ8","RU000A0JQZ00","RU000A0JTCM6","RU000A0JUBD5","SU25076RMFS9","SU26207RMFS9","RU000A0JRG44","RU000A0JTX33","SU25077RMFS7","RU000A0JS8R5","RU000A0JU179","RU000A0JU963","SU26212RMFS9","GAZPM","SBER","MGNT","LKOH","GMKN","ROSN","VTBR","URKA","SNGSP","SBERP","RIM4","ESM14.US","UXM4" });


		}


//		Client socket;
//		public void Execute()
//		{
//			Console.WriteLine("Starting SocketIO4Net Client Events Example...");
//
//			socket = new Client("http://localhost:3000/")
//			{
//			}; // url to the nodejs / socket.io instance
//			//socket.TransportPeferenceTypes.Add(TransportType.XhrPolling);
//			socket.Opened += SocketOpened;
//			socket.Message += SocketMessage;
//			socket.SocketConnectionClosed += SocketConnectionClosed;
//			socket.Error += SocketError;
//
//			// Optional to add HandShake headers - comment out if you do not have use
//			//socket.HandShake.Headers.Add("OrganizationId", "1034");
//			//socket.HandShake.Headers.Add("UserId", "TestSample");
//			//socket.HandShake.Headers.Add("Cookie", "somekookie=magicValue");
//			// Register for all On Events published from the server - prior to connecting
//
//			// register for 'connect' event with io server
//			socket.On("connect", (fn) =>
//				{
//					//		Console.WriteLine("\r\nConnected event...{0}\r\n", socket.ioTransport.TransportType);
//					socket.Emit("subscribe", new { room = "eventRoom" }); // client joins 'eventRoom' on server
//				});
//
//
//			// register for 'update' events - message is a json 'Part' object
//			socket.On("update", (data) =>
//				{
//					Console.WriteLine("recv [socket].[update] event");
//					Console.WriteLine("  raw message:      {0}", data.RawMessage);
//					Console.WriteLine("  string message:   {0}", data.MessageText);
//					Console.WriteLine("  json data string: {0}", data.Json.ToJsonString());
//					// cast message as Part - use type cast helper
//					//Part part = data.Json.GetArgAs<Part>();
//					//Console.WriteLine(" PartNumber:   {0}\r\n", part.PartNumber);
//				});
//
//			// register for 'alerts' events - broadcast only to clients joined to 'Room1'
//			socket.On("log", (data) =>
//				{
//					Console.WriteLine(" log: {0}", data.Json.ToJsonString());
//				});
//			socket.On("empty", (data) =>
//				{
//					Console.WriteLine(" message 'empty'");
//				});
//			//socket.Connect(SocketIOClient.TransportType.XhrPolling);
//			socket.Connect();
//		}
//
//		public void SendMessageSamples()
//		{
//
//			// random examples of different styles of sending / recv payloads - will add to...
//			socket.Send(new TextMessage("Hello from C# !")); // send plain string message
//			socket.Emit("hello", new { msg = "My name is SocketIO4Net.Client!" }); // event w/string payload
//			//socket.Emit("heartbeat"); // event w/o data payload (nothing to do with socket.io heartbeat)
//
//			//socket.Emit("hello", "simple string msg");
//			//socket.Emit("partInfo", new { PartNumber = "AT80601000741AA", Code = "SLBEJ", Level = 1 }); // event w/json payload
//
//			//Part newPart = new Part() { PartNumber = "K4P2G324EC", Code = "DDR2", Level = 1 };
//			//socket.Emit("partInfo", newPart); // event w/json payload
//
//
//			// callback using namespace example 
//			//Console.WriteLine("Emit [socket.logger].[messageAck] - should recv callback [socket::logger].[messageAck]");
//			//socket.Emit("messageAck", new { hello = "papa" }, "",
//			//	(callback) =>
//			//	{
//			//		var jsonMsg = callback as JsonEncodedEventMessage; // callback will be of type JsonEncodedEventMessage, cast for intellisense
//			//		Console.WriteLine(string.Format("callback [socket::logger].[messageAck]: {0} \r\n", jsonMsg.ToJsonString()));
//			//	});
//		}
//
//		void SocketError(object sender, ErrorEventArgs e)
//		{
//			Console.WriteLine("socket client error:");
//			Console.WriteLine(e.Message);
//		}
//
//		void SocketConnectionClosed(object sender, EventArgs e)
//		{
//			Console.WriteLine("WebSocketConnection was terminated!");
//		}
//
//		void SocketMessage(object sender, MessageEventArgs e)
//		{
//			// uncomment to show any non-registered messages
//			if (string.IsNullOrEmpty(e.Message.Event))
//				Console.WriteLine("Generic SocketMessage: {0}", e.Message.MessageText);
//			else
//				Console.WriteLine("Generic SocketMessage: {0} : {1}", e.Message.Event, e.Message.JsonEncodedMessage.ToJsonString());
//		}
//
//		void SocketOpened(object sender, EventArgs e)
//		{
//
//		}
//
//		public void Close()
//		{
//			if (this.socket != null)
//			{
//				socket.Opened -= SocketOpened;
//				socket.Message -= SocketMessage;
//				socket.SocketConnectionClosed -= SocketConnectionClosed;
//				socket.Error -= SocketError;
//				this.socket.Dispose(); // close & dispose of socket client
//			}
//		}

		void SocketOpened (object sender, EventArgs e)
		{
			Console.WriteLine("SocketOpened {0}", e);
		}

		void SocketMessage (object sender, MessageEventArgs e)
		{
			Console.WriteLine("SocketMessage {0}", e.Message.RawMessage);
		}

		void SocketConnectionClosed (object sender, EventArgs e)
		{
			Console.WriteLine("SocketConnectionClosed");
		}

		void SocketError (object sender, ErrorEventArgs e)
		{
			Console.WriteLine("SocketError");
		}
	}
}

