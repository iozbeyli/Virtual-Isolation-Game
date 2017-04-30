using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class HTTPCommunicationController{

	public HTTPCommunicationHelper httpHelper;

	private static HTTPCommunicationController instance=null;
	public static HTTPCommunicationController getInstance(){
		if (instance == null) {
			instance = new HTTPCommunicationController ();
		}
		return instance;
	}
	private HTTPCommunicationController (){}

	public void successfulExecution(string response,HTTPCommunicator communicator){
		Debug.Log (response);
		JSONObject responseJSONObject = new JSONObject(response);
		JSONObject data = responseJSONObject.GetField("data");
		communicator.successfulExecution (data);
	}

	public void failedExecution(string error,HTTPCommunicator communicator){
		communicator.failedExecution (error);
	}

	public void checkHelper(){
		if (httpHelper == null) {
			httpHelper = GameObject.Find ("HTTPCommunicationHelper").GetComponent<HTTPCommunicationHelper> ();
		}
	} 

	public void postJSONData(string url,JSONObject postData,HTTPCommunicator communicator){
		Dictionary<string,string> headers = new Dictionary<string,string>();
		headers.Add("Content-Type", "application/json");
		byte[] body = Encoding.ASCII.GetBytes(postData.ToString().ToCharArray());
		WWW www = new WWW (url,body,headers);
		checkHelper ();
		httpHelper.runAsyncRequest (www,communicator);
	}

	public void getJSONData(string url,HTTPCommunicator communicator){
		WWW www = new WWW (url);
		checkHelper ();
		httpHelper.runAsyncRequest (www, communicator);
	}


}
