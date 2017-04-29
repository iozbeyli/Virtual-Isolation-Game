using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserUIController : MonoBehaviour {

	public GameObject userPanel;
	public Text usernameText;

	public void openCloseUserPanel(){
		userPanel.SetActive (!userPanel.activeInHierarchy);
	}

	public void setUsername(){
		usernameText.text=MainUser.getInstance().Username;
	}

	public void update(){
		string username = MainUser.getInstance ().Username;
		if (!username.Equals ("")) {
			openCloseUserPanel ();
			setUsername();
		}
	}

}
