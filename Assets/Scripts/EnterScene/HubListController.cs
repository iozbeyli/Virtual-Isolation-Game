using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class HubListController : HTTPCommunicator {

	private static HubListController instance;
	public static HubListController getInstance(){
		if (instance == null) {
			instance = new HubListController ();
		}
		return instance;
	}
	private HubListController(){}

	public void getHubList(){
		HTTPCommunicationController.getInstance ().getJSONData (Constants.GET_HUB_LIST_API_URL,this);	
	}

	public 	void successfulExecution	(JSONObject data){	
		Debug.Log (data.ToString ());
		parseData(data);
	}

	public 	void failedExecution		(string error){	}

	public Hub parseDataToHub(JSONObject data){
		string id = data.GetField ("_id").str;
		string label = data.GetField ("label").str;
		string date = data.GetField ("date").str;
		bool started = data.GetField ("started").b;
		List<string> rooms =  JSONOperations.JSONArrayToStringArray (data, "rooms");
		List<string> members = JSONOperations.JSONArrayToStringArray (data, "members");
		Hub hub = new Hub (label);
		hub.ID = id;
		hub.Date = date;
		hub.Started = started;
		hub.Rooms = rooms;
		hub.Members = members;
		return hub;
	}

	public void parseData(JSONObject data){
		List<Hub> hubs = new List<Hub> ();
		if(data.type == JSONObject.Type.ARRAY){}
		foreach(JSONObject j in data.list ){
			hubs.Add (parseDataToHub (j));
		}
		EnterSceneUIController.HubUIController.listHubs (hubs);
	}

	public void joinHub(Hub item){
		Debug.Log ("join hub to" + item.ID);
		CommunicationScript comm = GameObject.Find ("HTTPCommunicationHelper").GetComponent<CommunicationScript> ();
		Dictionary<string,string> data = new Dictionary<string,string> ();
		data ["token"] = Session.getInstance ().Token;
		data ["hubId"] = item.ID;
		comm.emitMessage (Constants.HUB_JOIN_CHANNEL,data);
		HubController.getInstance().listenJoin ();
	}

}
