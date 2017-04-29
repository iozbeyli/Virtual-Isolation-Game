using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONOperations{

	public static List<string> JSONArrayToStringArray(JSONObject data,string dataField){
		
		JSONObject roomsJSONObject = data.GetField (dataField);
		if (roomsJSONObject.type != JSONObject.Type.ARRAY) {
			Debug.LogError ("Data is not an array");
			return null;
		}
		List<JSONObject> rooms = roomsJSONObject.list;
		List<string> roomIds = new List<string> ();
		foreach (JSONObject room in data.list) {
			string roomString = room.str;
			roomIds.Add (roomString);
		}
		return roomIds;
	}
}
