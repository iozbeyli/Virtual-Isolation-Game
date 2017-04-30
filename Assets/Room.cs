using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room{

	public string label = "";
	public List<Equipment> equipments=new List<Equipment>();
	public int roomSize = 0;
	public int remainingSize = 0;
	public int roomNumber = 0;
	public bool passive = false;
	public Room(){
	
	}

	public void setRoomSize(int roomSize){
		this.roomSize = roomSize;
		this.remainingSize = roomSize;
	}

	public void addEquipment(Equipment eq){
		Debug.Log ("adding eq" + eq.label);
			equipments.Add (eq);

	}

}
