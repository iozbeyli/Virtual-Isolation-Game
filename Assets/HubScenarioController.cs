using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubScenarioController : HTTPCommunicator{

	private List<Scenario> hubScenarios=new List<Scenario>();

	private static HubScenarioController instance=null;
	public static HubScenarioController getInstance(){
		if (instance == null) {
			instance = new HubScenarioController ();
		}
		return instance;
	}
	private HubScenarioController(){}

	public void getScenarios(){
		HTTPCommunicationController.getInstance ().getJSONData (Constants.GET_HUB_SCENARIO, this);
	}

	public void listScenarios(){
		EnterSceneUIController.HubControlUIController.listScenario (hubScenarios);
	}

	public 	void successfulExecution(JSONObject data){	
		Debug.Log ("Scenario" + data.ToString ());
		List<JSONObject> scenarios = data.list;
		foreach (JSONObject j in scenarios) {
			hubScenarios.Add (JSONParser.parseScenarioMessage (j));	
		}
		listScenarios ();
	}


	public 	void failedExecution(string error){		
	}

	public void chooseScenario(Scenario scenario){
		HubRoomController.getInstance ().setRoomCount (scenario.roomCount);
		EnterSceneUIController.HubControlUIController.openCloseScenarioPanel ();
	}

}
