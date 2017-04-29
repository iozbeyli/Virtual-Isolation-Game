using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class HubChatController{

	public static void sendMessageToChat(){
		string message = EnterSceneUIController.HubControlUIController.chatMessageInputField.text;
		Dictionary<string,string> data = new Dictionary<string,string> ();
		data ["message"] = message;
		data ["token"] = Session.getInstance ().Token;
		SocketCommunicationController.emitMessage (Constants.HUB_CHAT_CHANNEL, data);
	}

	public static void listenChat(){
		SocketCommunicationController.listenEvent (Constants.HUB_CHAT_CHANNEL+"d", (SocketIOEvent e) => {
			Debug.Log(e.data.ToString());
		});
	}

}
