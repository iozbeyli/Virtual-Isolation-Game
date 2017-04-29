using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubCreationController : HTTPCommunicator{

	private static HubCreationController instance = null;
	public static HubCreationController getInstance(){
		if (instance == null) {
			instance = new HubCreationController ();
		}
		return instance;
	}
	private HubCreationController (){}

	public void createHub(string name){
		JSONObject data = new JSONObject ();
		data.AddField ("label", name);
		JSONObject arr = new JSONObject(JSONObject.Type.ARRAY);
		data.AddField("members", arr);
		arr.Add (MainUser.getInstance ().ID);
		Debug.Log (data.ToString ());
		HTTPCommunicationController.getInstance ().postJSONData (Constants.CREATE_HUB_API_URL, data, this);
	}

	public void successfulExecution(JSONObject data){
		Debug.Log (data.ToString());
	}

	public void failedExecution(string error){
		
	}
}
