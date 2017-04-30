using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubRoomUIController : MonoBehaviour {
	public List<GameObject> rooms;
	public void setRoomCount(int count){
		for (int i = 0; i < rooms.Count; i++) {
			if (count == 0) {
				rooms [i].SetActive (false);
			} else if (count == 5) {
				rooms [i].SetActive (true);
			} else if (count == 3) {
				if (i == 2 || i == 3) {
					rooms [i].SetActive (false);
				} else {
					rooms [i].SetActive (true);
				}
			}
		}
	}

}
