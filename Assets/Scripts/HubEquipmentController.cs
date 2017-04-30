using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubEquipmentController : HTTPCommunicator{

	public List<Equipment> equipments;

	private static HubEquipmentController instance=null;
	public static HubEquipmentController getInstance(){
		if (instance == null) {
			instance = new HubEquipmentController ();
		}
		return instance;
	}
	private HubEquipmentController(){}

	public void getEquipments(){
		Debug.Log ("get equipments");
		HTTPCommunicationController.getInstance ().getJSONData (Constants.GET_HUB_EQUIPMENT, this);
	}

	public void listEquipments(){
		EnterSceneUIController.HubEquipmentUIController.listEquipment (equipments);
	}

	public 	void successfulExecution(JSONObject data){	
		Debug.Log ("Equipment" + data.ToString ());
		equipments = new List<Equipment> ();
		foreach (JSONObject e in data.list) {
			Equipment equipment = JSONParser.parseEquipmentMessage (e);
			equipments.Add (equipment);
		}
		listEquipments ();
		/*List<JSONObject> scenarios = data.list;
		foreach (JSONObject j in scenarios) {
			equipments.Add (JSONParser.parseScenarioMessage (j));	
		}*/
		//listScenarios ();
	}


	public 	void failedExecution(string error){		
	}

	public void addEquipment(Equipment e){
		Debug.Log ("equipment added");
		HubRoomController.getInstance ().selectedRoom.addEquipment (e);
		EnterSceneUIController.HubEquipmentUIController.openCloseEquipmentPanel ();
	}


}
