using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class HubControlUIController : MonoBehaviour, ScrollLister<User> , ScrollLister<ChatMessage>, ScrollLister<Scenario> {
	public GameObject dummyCrewObject;
	public Transform crewPrefab;
	public GameObject crewScrollPanel;
	public ScrollListCreator<User> crewScrollListCreator;

	public InputField chatMessageInputField;
	public GameObject dummyChatMessageObject;
	public Transform chatMessagePrefab;
	public GameObject chatMessageScrollPanel;
	public ScrollListCreator<ChatMessage> chatMessageScrollListCreator;

	public GameObject dummyScenarioObject;
	public Transform scenarioPrefab;
	public GameObject scenarioScrollPanel;
	public ScrollListCreator<Scenario> scenarioScrollListCreator;
	public GameObject hubScenarioPanel;

	public void listScenario(List<Scenario> scenarios){
		checkScenarioScrollListCreator ();
		scenarioScrollListCreator.resetList ();
		scenarioScrollListCreator.listObjects (scenarios, this);
	}

	public GameObject setScrollItem(Scenario item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.title;
		//Debug.Log ("item username id" + item.Username);
		scenarioScrollListCreator.continueListing (itemObject);
		Button button = itemObject.GetComponent<Button> ();
		//Button[] button = itemObject.GetComponentsInChildren<Button> ();
		UnityAction action = () => {
			HubScenarioController.getInstance().chooseScenario(item);
		};
		button.onClick.AddListener (action);
		return itemObject;
	}

	public void checkScenarioScrollListCreator(){
		if (scenarioScrollListCreator == null) {
			scenarioScrollListCreator = new ScrollListCreator<Scenario> (scenarioScrollPanel,dummyScenarioObject,scenarioPrefab,"Scenario");
		}
	}

	public void listCrew(List<User> users){
		checkCrewScrollListCreator ();
		crewScrollListCreator.resetList ();
		crewScrollListCreator.listObjects (users, this);
	}

	public GameObject setScrollItem(User item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		texts [0].text = item.Username;
		Debug.Log ("item username id" + item.Username);
		crewScrollListCreator.continueListing (itemObject);
		return itemObject;
	}
		
	public void checkCrewScrollListCreator(){
		if (crewScrollListCreator == null) {
			crewScrollListCreator = new ScrollListCreator<User> (crewScrollPanel,dummyCrewObject,crewPrefab,"Crew");
		}
	}

	public void listChatMessages(List<ChatMessage> messages){
		checkChatMessageScrollListCreator ();
		chatMessageScrollListCreator.resetList ();
		chatMessageScrollListCreator.listObjects (messages, this);
	}

	public GameObject setScrollItem(ChatMessage item, GameObject itemObject){
		Text[] texts = itemObject.GetComponentsInChildren<Text> ();
		if (texts [0].gameObject.name.Equals ("MessageTitle")) {
			texts [0].text = item.Sender.Username;
			Debug.Log ("item username is" + item.Sender.Username);
			texts [1].text = item.Content;
		} else {
			texts [1].text = item.Sender.Username;
			Debug.Log ("item username is" + item.Sender.Username);
			texts [0].text = item.Content;
		}
		Debug.Log("Height is "+itemObject.GetComponent<RectTransform>().rect.size.y);
		StartCoroutine (WaitForItemHeight (itemObject));
		return itemObject;
	}

	public IEnumerator WaitForItemHeight(GameObject itemObject) {
		yield return new WaitForEndOfFrame();
		chatMessageScrollListCreator.continueListing (itemObject);
	}
		
	public void checkChatMessageScrollListCreator(){
		if (chatMessageScrollListCreator == null) {
			chatMessageScrollListCreator = new ScrollListCreator<ChatMessage> (chatMessageScrollPanel,dummyChatMessageObject,chatMessagePrefab,"ChatMessage");
		}
	}

	public void sendMessage(){
		HubChatController.sendMessageToChat ();
	}

	public void startGame(){
		Debug.Log ("start game");
		HubRoomController.getInstance ().sendAddRoom ();

		//SceneManager.LoadScene (1);
	}

	public void openCloseScenarioPanel(){
		hubScenarioPanel.SetActive (!hubScenarioPanel.activeInHierarchy);
	}
}
