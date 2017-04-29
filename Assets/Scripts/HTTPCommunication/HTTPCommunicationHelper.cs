using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTTPCommunicationHelper : MonoBehaviour {

	private HTTPCommunicationController httpController = null;

	public void runAsyncRequest(WWW www,HTTPCommunicator communicator){
		StartCoroutine(WaitForRequest(www,communicator));
	}

	IEnumerator WaitForRequest(WWW www,HTTPCommunicator communicator)
	{

		yield return www;
		if (httpController == null) {
			httpController=HTTPCommunicationController.getInstance ();
		}
		// check for errors

		if (www.error == null)
		{
			httpController.successfulExecution (www.text,communicator );
		} else {
			httpController.failedExecution (www.error,communicator);
		}    
	} 
}
