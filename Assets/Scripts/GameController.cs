using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour,HTTPCommunicator {
	
	void Start () {
		JSONObject data = new JSONObject ();
		HTTPCommunicationController.getInstance ().getJSONData (Constants.GET_MY_HUB_URL + "/" + MainUser.getInstance ().ID, this);
	}

	public 	void successfulExecution	(JSONObject data)					{	
		Debug.Log ("MyHub" + data.ToString ());
	}


	public 	void failedExecution		(string error)						{		
	}


}
