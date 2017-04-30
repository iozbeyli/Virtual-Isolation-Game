using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HubRoomUIController : MonoBehaviour {
	public List<GameObject> rooms;

	public void setRoomCount(int count){
		HubRoomController.getInstance ().rooms = new List<Room> ();
		for (int i = 0; i < rooms.Count; i++) {
			Room room = new Room ();
			Button button = rooms [i].GetComponent<Button> ();
			room.roomNumber = i;

			if (count == 0) {
				rooms [i].SetActive (false);
				room.passive = true;

			} else if (count == 5) {
				rooms [i].SetActive (true);
				room.passive = false;


			} else if (count == 3) {
				if (i == 2 || i == 3) {
					rooms [i].SetActive (false);
					room.passive = true;
				} else {
					rooms [i].SetActive (true);
					room.passive = false;
				}
			}

			HubRoomController.getInstance ().rooms.Add (room);
			UnityAction action = () => {
				HubRoomController.getInstance().selectRoom(room);
			};
			button.onClick.AddListener (action);
		}

	}

}
