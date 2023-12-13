/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
	public class OSCMessageTransmitter : MonoBehaviour
	{
		#region Public Vars

		private string Address_1 = "/api_1";
		private string Address_2 = "/api_2";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			var message = new OSCMessage(Address_1);
			message.AddValue(OSCValue.String("Hello, world!"));
			Transmitter.Send(message);
		}

		public void SendMessageKeyOne(string Content){
			var message = new OSCMessage(Address_1);	
			message.AddValue(OSCValue.String(Content));
			Transmitter.Send(message);
		}

		public void SendMessageKeyTwo(string Content){
			var message = new OSCMessage(Address_2);	
			message.AddValue(OSCValue.String(Content));
			Transmitter.Send(message);
		}

		#endregion
	}
}