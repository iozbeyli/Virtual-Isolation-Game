using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class HubChatController{

	private static List<ChatMessage> messages=new List<ChatMessage>();

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
			ChatMessage chatMessage = JSONParser.parseChatMessage(e.data);
			messages.Add(chatMessage);
			Debug.Log(chatMessage.Content);
			if(messages.Count>6){
				messages.RemoveAt(0);
			}
			EnterSceneUIController.HubControlUIController.listChatMessages(messages);
		});
	}

}
