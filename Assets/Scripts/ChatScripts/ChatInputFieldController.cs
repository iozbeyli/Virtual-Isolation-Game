using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatInputFieldController: MonoBehaviour {
	public InputField chatInputField;
	public CommunicationScript communicationScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnEndEdit(){
		string message = chatInputField.text;
		communicationScript.sendMessage (message);
	}
}
