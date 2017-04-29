using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : HTTPCommunicator{

	private static LoginController instance = null;
	public 	static LoginController getInstance(){
		if (instance == null) {
			instance = new LoginController ();
		}
		return instance;
	}
	private LoginController(){}

	public  void login					(string username,string password)	{	JSONObject data = new JSONObject ();
																				data.AddField ("username", username);
																				data.AddField ("password", password);
																				HTTPCommunicationController.getInstance ().postJSONData (Constants.LOGIN_API_URL, data, this);	
	}

	public 	void successfulExecution	(JSONObject data)					{	Debug.Log (data.ToString ()); parseResponseData (data);
																				EnterSceneUIController.AuthenticationUIController.loginToHub ();}

	public 	void failedExecution		(string error)						{																							}

	public  void parseResponseData(JSONObject data){
		JSONObject tokenObject = data.GetField ("token");
		Session.getInstance ().Token = tokenObject.str;
		JSONObject idObject = data.GetField ("_id");
		MainUser.getInstance ().ID = idObject.str;
		Debug.Log (MainUser.getInstance ().ID);
		MainUser.getInstance ().Username = data.GetField ("username").str;
		Debug.Log (MainUser.getInstance ().Username);
	}

}
