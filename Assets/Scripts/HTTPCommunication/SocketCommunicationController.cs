using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
public class SocketCommunicationController{

	private static SocketIOComponent socket=null;
	private static SocketIOComponent Socket{
		get{ 
			checkSocketComponent ();
			return socket;
		}
	}
	private static void checkSocketComponent(){
		if (socket == null) {
			socket = GameObject.Find ("SocketIO").GetComponent<SocketIOComponent>();
		}
	}

	public static void emitMessage(string channel,Dictionary<string, string> data){
		Socket.Emit (channel	, new JSONObject(data));
	}
	public static void emitMessageJSON(string channel,JSONObject json){
		Socket.Emit (channel	, json);
	}

	public static void listenEvent(string channel,Action<SocketIOEvent> callback){
		Socket.On (channel, callback);
	}




}
