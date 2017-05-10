using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
public class HubController{
	private Hub currentHub=null;
	private List<User> hubCrew = new List<User>();

	private static HubController instance=null;
	public static HubController getInstance(){
		if (instance == null) {
			instance = new HubController ();
		}
		return instance;
	}
	private HubController(){
	}

	public void goIntoHub(){
		
	}

	public void listenJoin(){
		SocketCommunicationController.listenEvent (Constants.HUB_JOIN_CHANNEL, (SocketIOEvent e) => {
			Debug.Log(e.data.ToString());
			JSONObject data = e.data;
			JSONObject hubObject = data.GetField("hub");
			Hub hub = JSONParser.parseHub(hubObject);
			JSONObject userObject = data.GetField("user");
			User user = JSONParser.parseUser(userObject);
			if(currentHub == null){
				if(user.ID.Equals(MainUser.getInstance().ID)){
					currentHub = hub;

					successfulJoin();
				}
			}else{
				if(user.ID.Equals(MainUser.getInstance().ID)){
					//currentHub = hub;
					//successfulJoin();
				}else{
					Debug.Log("A wild user appeared");
					addCrewMember(user);

				}
			}

		});
	}

	public void listenLeave(){
		
	}

	public void successfulJoin(){
		EnterSceneUIController.HubUIController.openCloseHubControlPanel ();
		hubCrew.Add (MainUser.getInstance ().user);
		EnterSceneUIController.HubControlUIController.listCrew (hubCrew);
		HubChatController.listenChat ();
		HubScenarioController.getInstance ().getScenarios ();
		HubEquipmentController.getInstance ().getEquipments ();
		listenLeave ();
	
	}

	public void addCrewMember(User user){
		hubCrew.Add (user);
		EnterSceneUIController.HubControlUIController.listCrew (hubCrew);
	}

}
