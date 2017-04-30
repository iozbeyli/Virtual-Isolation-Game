using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class GameRoomUIController {

	List<Equipment> eqs = new List<User>();

	public void room1Click(){
		enterRoom ("0");
		listenChat ("0");
	}

	public void room2Click(){
		enterRoom ("1");
		listenChat ("1");
	}

	public void room3Click(){
		enterRoom ("2");
		listenChat ("2");
	}

	public void room4Click(){
		enterRoom ("3");
		listenChat ("3");
	}

	public void room5Click(){
		enterRoom ("4");
		listenChat ("4");
	}

	public static void enterRoom(string id){
		Dictionary<string,string> data = new Dictionary<string,string> ();
		data ["roomId"] = id;
		data ["token"] = Session.getInstance ().Token;
		SocketCommunicationController.emitMessage (Constants.ROOM_ENTER, data);
	}

	public static void listenChat(string id){
	}
}
