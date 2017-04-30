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

	public static ChatMessage parseChatMessage(JSONObject data){
		ChatMessage chatMessage = new ChatMessage ();
		JSONObject senderObject = data.GetField ("sender");
		User user = parseUser (senderObject);
		JSONObject payloadObject = data.GetField ("payload");
		chatMessage.ID = payloadObject.GetField ("_id").str;
		chatMessage.Content = payloadObject.GetField ("message").str;
		chatMessage.Date = payloadObject.GetField ("sendedAt").str;
		chatMessage.Sender = user;
		return chatMessage;
	}

	public static Scenario parseScenarioMessage(JSONObject data){
		Scenario scenario = new Scenario ();
		scenario.id = data.GetField ("_id").str;
		scenario.title = data.GetField ("title").str;
		scenario.description = data.GetField ("description").str;
		scenario.crewSize = (int)data.GetField ("crewSize").n;
		scenario.duration = (int)data.GetField ("duration").n;
		scenario.roomCount = (int)data.GetField ("roomCount").n;
		List<JSONObject> taskArray = data.GetField ("tasks").list;
		List<Task> tasks = new List<Task> ();
		foreach (JSONObject t in taskArray) {
			Task task = parseTaskMessage (t);
			tasks.Add (task);
		}
		scenario.tasks = tasks;

		return scenario;
	}

	public static Task parseTaskMessage(JSONObject data){
		Task task = new Task ();
		task.ID = data.GetField ("_id").str;
		task.Title = data.GetField ("label").str;
		task.Description = data.GetField ("description").str;
		task.Duration = (int)data.GetField ("duration").n;
		task.Deadline = (int)data.GetField ("deadline").n;
		return task;
	}

}
