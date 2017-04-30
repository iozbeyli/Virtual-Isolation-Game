using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class HubRoomController{
	public int roomCount=0;
	public List<Room> rooms=new List<Room>();
	public Room selectedRoom;
	private static HubRoomController instance;
	public static HubRoomController getInstance(){
		if (instance == null) {
			instance = new HubRoomController ();
		}
		return instance;
	}

	public void setRoomCount(int count){
		EnterSceneUIController.HubRoomUIController.setRoomCount (count);
	}

	public void createRooms(int roomNumber){
		for (int i = 0; i < roomNumber; i++) {
			Room room = new Room ();
			room.roomNumber = i;
		}

	}

	public void sendAddRoom(){
		Debug.Log ("send"+rooms.Count);

		foreach (Room room in rooms) {
			if (room.passive == false) {
				Debug.Log ("emittin send room");
				SocketCommunicationController.emitMessageJSON("hub:addRoom",JSONParser.parseRoomToJSON(room));
			}
		}
	}

	public void listenAddRoom(){
		SocketCommunicationController.listenEvent ("hub:newRoom", (SocketIOEvent obj) => {
			Debug.Log (obj.data);
		});
	}

	public void selectRoom(Room room){
		Debug.Log ("roomSelected");
		selectedRoom = room;
		EnterSceneUIController.HubEquipmentUIController.openCloseEquipmentPanel ();
	}

}
