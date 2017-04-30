using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubRoomController{
	public int roomCount=0;

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

}
