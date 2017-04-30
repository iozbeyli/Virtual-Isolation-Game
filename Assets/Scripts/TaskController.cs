using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class TaskController{

	List<Task> _chores;
	List<Task> _tasks;

	private static TaskController instance=null;
	public static TaskController getInstance(){
		if (instance == null) {
			instance = new TaskController ();
		}
		return instance;
	}
	private TaskController(){}

	public void getTasks(){
		Debug.Log (Session.getInstance ().currentHub);
		Dictionary<string,string> edata = new Dictionary<string,string> ();
		edata ["token"] = Session.getInstance ().Token;
		edata ["hubId"] = Session.getInstance().currentHub;
		SocketCommunicationController.emitMessage("hub:start",edata);
		//SocketCommunicationController.emitMessageJSON(Constants.HUB_JOIN_CHANNEL,new JSONObject("{hubId:"+Session.getInstance().currentHub+", token:"+Session.getInstance().Token+" }"));
		Debug.Log ("send start");
		SocketCommunicationController.listenEvent (Constants.HUB_RECEIVE_TASKS, (SocketIOEvent e) => {
			Debug.Log(e.data.ToString());
			JSONObject data = e.data;

			Debug.Log ("Task" + data.ToString ());
			List<JSONObject> tasks = data.list;

			foreach (JSONObject j in tasks) {
				if(j.GetField("random").b)
					_chores.Add (JSONParser.parseTaskMessage (j));
				else
					_tasks.Add (JSONParser.parseTaskMessage (j));
			}
			listTasks ();
			listChores ();

		});
	}

	public void listTasks(){
		GameSceneUIController.TaskUIController.listTask (_tasks);
	}

	public void listChores(){
		GameSceneUIController.ChoreUIController.listChore (_chores);
	}
}
