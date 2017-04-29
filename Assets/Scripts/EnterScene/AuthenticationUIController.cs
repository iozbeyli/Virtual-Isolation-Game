using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AuthenticationUIController : MonoBehaviour {

	public GameObject loginPanel;
	public GameObject registerPanel;

	public InputField loginUsernameInputField;
	public InputField loginPasswordInputField;

	public void login(){
		string username = loginUsernameInputField.text;
		string password = loginPasswordInputField.text;
		LoginController.getInstance().login (username, password);
	}

	public void loginToRegister(){
		loginPanel.SetActive (false);
		registerPanel.SetActive (true);
	}

	public void loginToHub(){
		loginPanel.SetActive (false);
		EnterSceneUIController.HubUIController.openCloseHubPanel ();
	}

}
