using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
public class CommunicationScript : MonoBehaviour {
	SocketIOComponent socket;

	// Use this for initialization
	void Start () {

		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent> ();

		socket.On("error", (SocketIOEvent e) => {
			Debug.Log(string.Format("[name: {0}, data: {1}]", e.name, e.data));
		});

	}

	public void sendMessage(string message){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["ismet"] = message;
		socket.Emit("message"	,	new JSONObject(data));
	}

	public void emitMessage(string channel,Dictionary<string, string> data){
		socket.Emit (channel	, new JSONObject(data));
	}

	public void listenEvent(string channel,Action<SocketIOEvent> callback){
		socket.On ("channel", callback);
	}
}
