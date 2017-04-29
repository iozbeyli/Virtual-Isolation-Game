using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser{

	public static Hub parseHub(JSONObject data){
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

	public static User parseUser(JSONObject data){
		User user = new User();
		JSONObject idObject = data.GetField ("_id");
		user.ID = idObject.str;
		string username = data.GetField ("username").str;
		user.Username = username;
		return user;

	}

}
