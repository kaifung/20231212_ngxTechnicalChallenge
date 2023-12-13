/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;
using UnityEngine.UI;

namespace extOSC.Examples
{
	public class OSCMessageReceiver : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/example/1";
		public GameObject TestLog ;

		[Header("OSC Settings")]
		public OSCReceiver Receiver;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
			Receiver.Bind(Address, ReceivedMessage);
		}

		#endregion

		#region Private Methods

		private void ReceivedMessage(OSCMessage message)
		{
			Debug.LogFormat("Received: {0}", message);
			TestLog.GetComponent<UnityEngine.UI.Text>().text = message.ToString();
		}

		#endregion
	}
}