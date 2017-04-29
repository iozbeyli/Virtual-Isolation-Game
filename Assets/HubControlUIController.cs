using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class HubControlUIController : MonoBehaviour, ScrollLister<User> {
	public GameObject dummyCrewObject;
	public Transform crewPrefab;
	public GameObject crewScrollPanel;
	public ScrollListCreator<User> crewScrollListCreator;

	public InputField chatMessageInputField;

	public void listCrew(List<User> users){
		checkCrewScrollListCreator ();
		crewScrollListCreator.resetList ();
		crewScrollListCreator.listObjects (users, this);
	}

	public GameObject setScrollItem(User item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.Username;
		Debug.Log ("item username id" + item.Username);
		/*Button button = itemObject.GetComponentInChildren<Button> ();
		UnityAction action = () => {
			HubListController.getInstance().joinHub (item);
		};
		button.onClick.AddListener(action);*/
		return itemObject;
	}


	public void checkCrewScrollListCreator(){
		if (crewScrollListCreator == null) {
			crewScrollListCreator = new ScrollListCreator<User> (crewScrollPanel,dummyCrewObject,crewPrefab,"Crew");
		}
	}

	public void sendMessage(){
		HubChatController.sendMessageToChat ();
	}
}
